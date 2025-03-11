using Agenda.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Modelos.Models.Cadastro;
using Models.Cadastro;
using Services.Cadastro;
using System.Security.Claims;

namespace Agenda.Pages.Areas.Cadastro
{
    public class AtendimentosCadModel : PageBaseCadFormModel<AtendimentoCadVm>
    {
        private readonly IAtendimentoCadService _atendimentoCadService;
        private readonly ITipoAtendimentoService _tipoAtendimentoService;
        private readonly IPessoaService _pessoaService;
        public AtendimentosCadModel(IAtendimentoCadService atendimentoCadService,
            ITipoAtendimentoService tipoAtendimentoService,
            IPessoaService pessoaService) : base(atendimentoCadService)
        {
            _atendimentoCadService = atendimentoCadService;
            _tipoAtendimentoService = tipoAtendimentoService;
            _pessoaService = pessoaService;
        }
        
        public virtual List<TipoAtendimentoVm> TipoAtendimentoList { get; set; }
        public virtual List<PessoaVm> PessoaList { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            Edicao = !string.IsNullOrEmpty(Id);
            TipoAtendimentoList = await _tipoAtendimentoService.ListAllAsync();
            PessoaList = await _pessoaService.ListAllAsync();
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = User.Identity.Name;
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            EntityVm = new AtendimentoCadVm();
            if(!string.IsNullOrEmpty(Id))
            {
                EntityVm = await _atendimentoCadService.GetByIdAsync(Id);
                return Page();
            }
            else
            {
                EntityVm.Id = Guid.NewGuid().ToString("D");
                return Page();
            }
        }
    }
}
