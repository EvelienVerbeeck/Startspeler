using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StartSpelerMVC.Areas.Identity.Data;
using StartSpelerMVC.Data;
using StartSpelerMVC.Data.UnitOfWork;
using StartSpelerMVC.Models;

namespace StartSpelerMVC.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        private readonly IUnitOfWork _uow;

        public IndexModel(
            UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager,
            IUnitOfWork uow)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uow = uow;
        }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Naam")]
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
         
            [DataType(DataType.Text)]
            [Display(Name = "Voornaam")]
            public string Voornaam { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Achternaam")]
            public string Achternaam { get; set; }
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Gebruikersnaam")]
            public string Gebruikersnaam { get; set; }
            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Geboortedatum")]
            public DateTime Geboortedatum { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "E-mail adres")]
            public string Email { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Wachtwoord")]
            public string Password { get; set; }
            [Display(Name = "Is actief")]
            public bool IsActief { get; set; }
            [Display(Name = "Is Administrator")]
            public bool IsAdmin{ get; set; }
        }

        private async Task LoadAsync(CustomUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Persoon persoon = await _uow.PersoonRepository.GetFirstOrDefault(x => x.UserID == user.Id);
            user.Persoon = persoon;

            Input = new InputModel
            {
                Voornaam = user.Persoon.Voornaam,
                Achternaam = user.Persoon.Achternaam,
                Gebruikersnaam = user.Persoon.Username,
                Geboortedatum = user.Persoon.Geboortedatum,
                Email = user.Persoon.Email,
                Password=user.Persoon.Wachtwoord,
                IsActief=user.Persoon.IsActief,
                IsAdmin=user.Persoon.IsAdmin
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            Persoon persoon = await _uow.PersoonRepository.GetFirstOrDefault(x => x.UserID == user.Id);
            user.Persoon = persoon;
            user.Persoon.Voornaam = Input.Voornaam;
            user.Persoon.Achternaam = Input.Achternaam;
            user.Persoon.Username = Input.Gebruikersnaam;
            user.Persoon.Geboortedatum = Input.Geboortedatum;
            user.Persoon.Email = Input.Email;
            user.Persoon.Wachtwoord = Input.Password;
            user.Persoon.IsActief = Input.IsActief;
            user.Persoon.IsAdmin = Input.IsAdmin;

            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
