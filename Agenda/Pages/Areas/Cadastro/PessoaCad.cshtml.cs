using Agenda.Pages.Shared;
using Dados;
using Microsoft.AspNetCore.Mvc;
using Modelos.Models.Cadastro;
using Services.Cadastro;

namespace Agenda.Pages.Areas.Cadastro
{
    public class PessoaCadModel : PageBaseCadFormModel<PessoaVm>
    {
        private readonly IPessoaService _pessoaService;

        public PessoaCadModel(IPessoaService pessoaService) : base(pessoaService)
        {
            _pessoaService = pessoaService;
        }
        public bool PessoaCadastrada { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            Edicao = !string.IsNullOrEmpty(Id);
            EntityVm = new PessoaVm();
            if (!string.IsNullOrEmpty(Id))
            {
                EntityVm = _pessoaService.GetById(Id);
                PessoaCadastrada = true;
                return Page();
            }
            else
            {
                EntityVm.Id = Guid.NewGuid().ToString("D");
                EntityVm.TipoUsuario = TipoUsuarioEnum.Pessoal;
                return Page();
            }
        }

    }
}
