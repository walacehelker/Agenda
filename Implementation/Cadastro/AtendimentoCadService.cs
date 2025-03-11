using AutoMapper;
using Context;
using Dados.Cadastro;
using Microsoft.EntityFrameworkCore;
using Models.Cadastro;
using Services.Cadastro;

namespace Implementation.Cadastro
{
    public class AtendimentoCadService : BaseService<Atendimento, AtendimentoCadVm>, IAtendimentoCadService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        private readonly IAtendimentoService _atendimentoService;
        public AtendimentoCadService(AppDbContext appDbContext, IMapper mapper, IAtendimentoService atendimentoService) : base(appDbContext, mapper)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
            _atendimentoService = atendimentoService;
        }

        public override async Task<AtendimentoCadVm> GetByIdAsync(string id)
        {
            var dados = await _atendimentoService.GetByIdAsync(id);
            return MapearAtendimentoCadVm(dados);
        }

        private AtendimentoCadVm MapearAtendimentoCadVm(AtendimentoVm atendimento)
        {
            var atendimentoCadVm = new AtendimentoCadVm
            {
                Id = atendimento.Id,
                Descricao = atendimento.Descricao,
                DataAtendimento = atendimento.DataAtendimento,
                PessoaId = atendimento.PessoaId,
                TipoAtendimentoId = atendimento.TipoAtendimentoId
            };
            return atendimentoCadVm;
        }

        public override async Task AddAsync(AtendimentoCadVm TBaseVmEntity)
        {
            var atendimento = new Atendimento()
            {
                Id = TBaseVmEntity.Id,
                DataCadastro = TBaseVmEntity.DataCadastro,
                DataExclusao = TBaseVmEntity.DataExclusao,
                Excluido = TBaseVmEntity.Excluido,
                Descricao = TBaseVmEntity.Descricao,
                DataAtendimento = TBaseVmEntity.DataAtendimento,
                PessoaId = TBaseVmEntity.PessoaId,
                TipoAtendimentoId = TBaseVmEntity.TipoAtendimentoId
            };
            await GetDbSet().AddAsync(atendimento);
            await _appDbContext.SaveChangesAsync();
        }

        public override async Task UpdateAsync(AtendimentoCadVm TBaseVmEntity)
        {
            var existe = await GetDbSet().FindAsync(TBaseVmEntity.Id);
            if (existe != null)
            {
                existe.Descricao = TBaseVmEntity.Descricao;
                existe.DataAtendimento = TBaseVmEntity.DataAtendimento;
                existe.PessoaId = TBaseVmEntity.PessoaId;
                existe.TipoAtendimentoId = TBaseVmEntity.TipoAtendimentoId;
                existe.DataCadastro = TBaseVmEntity.DataCadastro;
                existe.Id = TBaseVmEntity.Id;
                existe.DataExclusao = TBaseVmEntity.DataExclusao;
                existe.Excluido = TBaseVmEntity.Excluido;
                GetDbSet().Update(existe);
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                AddAsync(TBaseVmEntity);
            }
        }

    }
}