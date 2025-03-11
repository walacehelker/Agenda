using AutoMapper;
using Context;
using Dados.Cadastro;
using Microsoft.EntityFrameworkCore;
using Models.Cadastro;
using Services.Cadastro;

namespace Implementation.Cadastro
{
    public class AtendimentoService : BaseService<Atendimento, AtendimentoVm>, IAtendimentoService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public AtendimentoService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public async Task<List<AtendimentoVm>> ListAllComPessoaAsync()
        {
            var entities = await GetDbSet()
                .Where(e => !e.Excluido)
                .Include(a => a.TipoAtendimento)
                .Select(a => new AtendimentoVm
                {
                    Id = a.Id,
                    Descricao = a.Descricao,
                    DataAtendimento = a.DataAtendimento,
                    PessoaId = a.PessoaId,
                    PessoaNome = a.Pessoa.Nome,
                    TipoAtendimentoNome = a.TipoAtendimento.Nome,
                }).ToListAsync();
            return entities;
        }
    }
}