using Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos.Models.Cadastro;
using Services.Cadastro;

namespace MyApp.Pages
{
    public class CadUsuarioModel : PageModel
    {
        private readonly IPessoaService _pessoaService;

        public CadUsuarioModel(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [BindProperty(SupportsGet = true)]
        public int? TipoCadastro { get; set; }

        [BindProperty]  
        public PessoaVm Pessoa { get; set; } = new PessoaVm();

        public void OnGet()
        {
            Pessoa.Id = Guid.NewGuid().ToString("D");
            Pessoa.TipoUsuario = TipoCadastro == 1 ? TipoUsuarioEnum.Profissional : TipoUsuarioEnum.Empresarial;
        }

        public IActionResult OnPost()
        {
            _pessoaService.Add(Pessoa);
            return RedirectToPage("/Auth/Login");
        }
    }
}
