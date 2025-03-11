using Models.Cadastro;

namespace Services.Cadastro
{
    public interface IAtendimentoService : IBaseService<AtendimentoVm>
    {
        Task<List<AtendimentoVm>> ListAllComPessoaAsync();
    }
}
