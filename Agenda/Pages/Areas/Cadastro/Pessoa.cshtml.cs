using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos.Models.Cadastro;
using Services.Cadastro;

namespace Agenda.Pages.Areas.Cadastro
{
    public class PessoaModel : PageModel
    {
        private readonly IPessoaService _pessoaervice;
        public PessoaModel(IPessoaService pessoaervice)
        {
            _pessoaervice = pessoaervice;
        }

        public List<PessoaVm> PessoaList { get; set; }
        public async Task OnGet()
        {
            PessoaList = await _pessoaervice.ListAllAsync();
        }
    }
}
