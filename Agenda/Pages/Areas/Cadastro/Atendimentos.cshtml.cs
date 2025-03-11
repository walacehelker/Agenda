using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Cadastro;
using Services.Cadastro;

namespace Agenda.Pages.Areas.Cadastro
{
    public class AtendimentosModel : PageModel
    {
        private readonly IAtendimentoService _atendimentoService;
        public AtendimentosModel(IAtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        public List<AtendimentoVm> AtendimentoList { get; set; }
        public async Task OnGet()
        {
            AtendimentoList = await _atendimentoService.ListAllComPessoaAsync();
        }
    }
}
