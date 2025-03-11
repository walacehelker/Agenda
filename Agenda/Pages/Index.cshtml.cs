using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            // Verificar se o usuário já está autenticado
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Home");
            }

            return Page();
        }
    }
}
