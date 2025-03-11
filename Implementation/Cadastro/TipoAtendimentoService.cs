using AutoMapper;
using Context;
using Dados.Cadastro;
using Models.Cadastro;
using Services.Cadastro;

namespace Implementation.Cadastro
{
    public class TipoAtendimentoService : BaseService<TipoAtendimento, TipoAtendimentoVm>, ITipoAtendimentoService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public TipoAtendimentoService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }
    }
}