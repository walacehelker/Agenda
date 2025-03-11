using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Cadastro;
using Services.Cadastro;

namespace Agenda.Pages.Areas.Cadastro
{
    public class TiposAtendimentosModel : PageModel
    {
        private readonly ITipoAtendimentoService _tipoAtendimentoService;
        public TiposAtendimentosModel(ITipoAtendimentoService tipoAtendimentoService)
        {
            _tipoAtendimentoService = tipoAtendimentoService;
        }

        public List<TipoAtendimentoVm> TipoAtendimentoList { get; set; }
        public async Task OnGet()
        {
            TipoAtendimentoList = await _tipoAtendimentoService.ListAllAsync();
        }
    }
}
