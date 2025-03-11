using Agenda.Pages.Shared;
using Models.Cadastro;
using Services.Cadastro;

namespace Agenda.Pages.Areas.Cadastro
{
    public class TiposAtendimentosCadModel : PageBaseCadFormModel<TipoAtendimentoVm>
    {
        private readonly ITipoAtendimentoService _tipoAtendimentoService;
        public TiposAtendimentosCadModel(ITipoAtendimentoService tipoAtendimentoService) : base(tipoAtendimentoService)
        {
            _tipoAtendimentoService = tipoAtendimentoService;
        }
    }
}
