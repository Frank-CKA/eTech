using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Proyecto1.Data.Repositorio.IRepositorio;
using Proyecto1.Models;
using Proyecto1.Utilities;

namespace Proyecto1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager; //Config de role manager - Martes 17
        private readonly IUnidadTrabajo _unidadTrabajo; //Config de unidad trabajo - Martes 17

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager, //Config de role manager - Martes 17
            IUnidadTrabajo unidadTrabajo) //Config de unidad trabajo - Martes 17
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager; //Config de role manager - Martes 17
            _unidadTrabajo = unidadTrabajo; //config de unidad trabajo - Martes 17
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(15, MinimumLength = 4)]
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string PhoneNumber { get; set; } //Added custom requirements for users - Martes 17

            [Required]
            public string Nombres { get; set; }

            [Required]
            public string Apellidos { get; set; }

            public string Direccion { get; set; }

            public string Ciudad { get; set; }

            public string Pais { get; set; }
            public string Telefono { get; set; }

            public string Role { get; set; }

            public IEnumerable<SelectListItem> ListaRol { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            Input = new InputModel()
            {
                ListaRol =
               _roleManager.Roles.Where(r => r.Name !=
                DS.Role_Cliente).Select(n => n.Name).Select(l => new SelectListItem //Added custom input for website roles - Martes 17
            {
                Text = l,
                Value = l
            })
            };

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid) //Added custom code for website roles using DS Class in Utilities - Martes 17
            {
                var user = new UsuarioAplicacion
                {
                    UserName = Input.UserName,
                    Email = Input.Email,
                    Nombres = Input.Nombres,
                    Apellidos = Input.Apellidos,
                    Direccion = Input.Direccion,
                    Ciudad = Input.Ciudad,
                    Pais = Input.Pais,
                    Telefono = Input.Telefono,
                    Role = Input.Role
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (!await _roleManager.RoleExistsAsync(DS.Role_Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(DS.Role_Admin));
                    }
                    if (!await _roleManager.RoleExistsAsync(DS.Role_Cliente))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(DS.Role_Cliente));
                    }
                    if (!await _roleManager.RoleExistsAsync(DS.Role_Inventario))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(DS.Role_Inventario));
                    }
                    if (!await _roleManager.RoleExistsAsync(DS.Role_Ventas))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(DS.Role_Ventas));
                    }
                    //inicialmente para crear los diferentes roles todos serán admin
                    //luego de ejecutado por primera vez comentar esta linea
                    //await _userManager.AddToRoleAsync(user, DS.Role_Admin); 

                    //CHECK THAT LINE IF ROLES HAVE ERRORS ^

                    if (user.Role == null)
                    {
                        await _userManager.AddToRoleAsync(user, DS.Role_Cliente);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, user.Role);
                    }

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        if (user.Role == null)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Usuario", new { Area = "Admin" });
                        }

                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
