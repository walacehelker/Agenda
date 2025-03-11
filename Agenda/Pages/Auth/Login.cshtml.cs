using Context;
using Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MyApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public LoginModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public string Usuario { get; set; }
        [BindProperty]
        public string Senha { get; set; }

        public IActionResult OnGet()
        {
            // Verificar se o usu�rio j� est� autenticado
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Home");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var usuarioLogin = _dbContext.UsuariosLogins.SingleOrDefault(u => u.Usuario == Usuario);

            if (usuarioLogin != null && PasswordHelper.VerifyPassword(usuarioLogin.Senha, Senha))
            {
                // Sucesso na autentica��o
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuarioLogin.Usuario),
                    new Claim(ClaimTypes.Email, usuarioLogin.Email), // Opcional
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimsIdentity);

                // Crie as propriedades de autentica��o
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Para manter o login persistente
                    ExpiresUtc = DateTime.UtcNow.AddHours(8)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

                return RedirectToPage("/Home"); // Redireciona para Home ap�s login bem-sucedido
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usu�rio ou senha inv�lidos");
                return Page();
            }

        }
    }
}
