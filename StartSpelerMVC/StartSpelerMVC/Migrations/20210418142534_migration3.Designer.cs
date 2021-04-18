﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StartSpelerMVC.Data;

namespace StartSpelerMVC.Migrations
{
    [DbContext(typeof(LocalStartSpelerConnection))]
    [Migration("20210418142534_migration3")]
    partial class migration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Bestelling", b =>
                {
                    b.Property<int>("Bestelling_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Persoon_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("Decimal(5,2)");

                    b.HasKey("Bestelling_ID");

                    b.HasIndex("Persoon_ID");

                    b.ToTable("Bestelling");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Drankkaart", b =>
                {
                    b.Property<int>("Drankkaart_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AantalSlots")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("Begindatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsBetaald")
                        .HasColumnType("bit");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("Decimal(5,2)");

                    b.HasKey("Drankkaart_ID");

                    b.ToTable("Drankkaart");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Evenement", b =>
                {
                    b.Property<int>("Evenement_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Einduur")
                        .HasColumnType("datetime2");

                    b.Property<string>("EvenementNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsZichtbaar")
                        .HasColumnType("bit");

                    b.Property<byte>("MaxDeelnemers")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("Decimal(5,2)");

                    b.Property<DateTime>("Startuur")
                        .HasColumnType("datetime2");

                    b.HasKey("Evenement_ID");

                    b.ToTable("Evenement");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Inschrijving", b =>
                {
                    b.Property<int>("Inschrijving_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Evenement_ID")
                        .HasColumnType("int");

                    b.Property<int?>("PersonenPersoon_ID")
                        .HasColumnType("int");

                    b.HasKey("Inschrijving_ID");

                    b.HasIndex("Evenement_ID");

                    b.HasIndex("PersonenPersoon_ID");

                    b.ToTable("Inschrijving");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Orderlijn", b =>
                {
                    b.Property<int>("Orderlijn_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bestelling_ID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductenProduct_ID")
                        .HasColumnType("int");

                    b.HasKey("Orderlijn_ID");

                    b.HasIndex("Bestelling_ID");

                    b.HasIndex("ProductenProduct_ID");

                    b.ToTable("Orderlijn");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Persoon", b =>
                {
                    b.Property<int>("Persoon_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("Drankkaart_ID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Geboortedatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActief")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)")
                        .HasMaxLength(4);

                    b.HasKey("Persoon_ID");

                    b.HasIndex("Drankkaart_ID");

                    b.ToTable("Persoon");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Product", b =>
                {
                    b.Property<int>("Product_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AankoopPrijs")
                        .HasColumnType("Decimal(5,2)");

                    b.Property<int>("Aantal")
                        .HasColumnType("int");

                    b.Property<int>("Aantal_in_Frigo")
                        .HasColumnType("int");

                    b.Property<int>("Aantal_in_stock")
                        .HasColumnType("int");

                    b.Property<float>("Alcoholpercentage")
                        .HasColumnType("real");

                    b.Property<DateTime>("EindDatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsZichtbaar")
                        .HasColumnType("bit");

                    b.Property<int>("Naam")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int?>("ProductType_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Product_ID1")
                        .HasColumnType("int");

                    b.Property<byte>("Slotwaarde")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("VerkoopPrijs")
                        .HasColumnType("Decimal(5,2)");

                    b.HasKey("Product_ID");

                    b.HasIndex("ProductType_ID");

                    b.HasIndex("Product_ID1");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.ProductType", b =>
                {
                    b.Property<int>("ProductType_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ProductType_ID");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Bestelling", b =>
                {
                    b.HasOne("StartSpelerMVC.Models.Persoon", "Persoon")
                        .WithMany("Bestellingen")
                        .HasForeignKey("Persoon_ID");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Inschrijving", b =>
                {
                    b.HasOne("StartSpelerMVC.Models.Evenement", "Evenement")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("Evenement_ID");

                    b.HasOne("StartSpelerMVC.Models.Persoon", "Personen")
                        .WithMany("Inschrijvingen")
                        .HasForeignKey("PersonenPersoon_ID");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Orderlijn", b =>
                {
                    b.HasOne("StartSpelerMVC.Models.Bestelling", "Bestelling")
                        .WithMany("Orderlijnen")
                        .HasForeignKey("Bestelling_ID");

                    b.HasOne("StartSpelerMVC.Models.Product", "Producten")
                        .WithMany()
                        .HasForeignKey("ProductenProduct_ID");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Persoon", b =>
                {
                    b.HasOne("StartSpelerMVC.Models.Drankkaart", "Drankkaart")
                        .WithMany()
                        .HasForeignKey("Drankkaart_ID");
                });

            modelBuilder.Entity("StartSpelerMVC.Models.Product", b =>
                {
                    b.HasOne("StartSpelerMVC.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductType_ID");

                    b.HasOne("StartSpelerMVC.Models.Product", null)
                        .WithMany("Orderlijnen")
                        .HasForeignKey("Product_ID1");
                });
#pragma warning restore 612, 618
        }
    }
}
