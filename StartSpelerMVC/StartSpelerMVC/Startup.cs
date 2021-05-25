using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StartSpelerMVC.Areas.Identity.Data;
using StartSpelerMVC.Data;
using StartSpelerMVC.Data.UnitOfWork;
using StartSpelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartSpelerMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<StartSpelerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("StartSpelerConnection")));
            services.AddDefaultIdentity<CustomUser>()
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<StartSpelerContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.Configure<IdentityOptions>(options =>
            {
                //passwoord settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;

                //Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                //user settings
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmonpqrstuvwxyzABCDEFGHIJKLMOPQRSTUVWXYZ0123456789-,@+";
                options.User.RequireUniqueEmail = false;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            CreateUserRoles(serviceProvider).Wait();

        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            StartSpelerContext connection = serviceProvider.GetRequiredService<StartSpelerContext>();

            List<IdentityResult> roleResultlijst = new List<IdentityResult>();
            IdentityResult roleResult;
            // admin rol toevoegen
            bool roleCheck = await roleManager.RoleExistsAsync("Admin");
            bool SpelerRol = await roleManager.RoleExistsAsync("Speler");
            if (!roleCheck && !SpelerRol)
            {
                //rol creëren en seeden naar de database
                roleResult = await roleManager.CreateAsync(new IdentityRole("Admin"));
                roleResultlijst.Add(roleResult);
                roleResult = await roleManager.CreateAsync(new IdentityRole("Speler"));
                roleResultlijst.Add(roleResult);
            }
            //toekennen admin rol naar de hoofdgebruiker
            //IdentityUser user = connection.Users.FirstOrDefault(u => u.Email == "r0614769@student.thomasmore.be");
            List<CustomUser> users = connection.Users.Include(x => x.Persoon).ToList();
            foreach (CustomUser user in users)
            {
                if (user != null)
                {
                    if (user.Email == "r0614769@student.thomasmore.be" || user.Persoon.IsAdmin == true)
                    {
                        DbSet<IdentityUserRole<string>> roles = connection.UserRoles;
                        IdentityRole adminrole = connection.Roles.FirstOrDefault(r => r.Name == "Admin");
                        if (adminrole != null)
                        {
                            if (!roles.Any(ur => ur.UserId == user.Id && ur.RoleId == adminrole.Id))
                            {
                                roles.Add(new IdentityUserRole<string>() { UserId = user.Id, RoleId = adminrole.Id });
                                connection.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            DbSet<IdentityUserRole<string>> roles = connection.UserRoles;
                            IdentityRole adminrole = connection.Roles.FirstOrDefault(r => r.Name == "Speler");
                            if (adminrole != null)
                            {
                                if (!roles.Any(ur => ur.UserId == user.Id && ur.RoleId == adminrole.Id))
                                {
                                    roles.Add(new IdentityUserRole<string>() { UserId = user.Id, RoleId = adminrole.Id });
                                    connection.SaveChanges();
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                            throw new Exception(ex.Message + "\n" + ex.InnerException);
                        }

                    }

                }

            }
        }
    }
}
