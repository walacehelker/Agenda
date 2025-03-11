using AutoMapper;
using Dados.Cadastro;
using Modelos.Models.Cadastro;
using Models.Cadastro;

namespace Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, PessoaVm>().ReverseMap();
            CreateMap<Atendimento, AtendimentoVm>().ReverseMap();
            CreateMap<TipoAtendimento, TipoAtendimentoVm>().ReverseMap();
        }
    }
}
