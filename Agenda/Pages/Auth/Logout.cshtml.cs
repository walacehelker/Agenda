using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MyApp.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        private readonly IAntiforgery _antiforgery;

        public LogoutModel(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            return RedirectToPage("/Index");
        }
    }
}
