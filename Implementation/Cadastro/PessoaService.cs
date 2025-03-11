using AutoMapper;
using Context;
using Dados.Cadastro;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modelos.Models.Cadastro;
using Services.Cadastro;

namespace Implementation.Cadastro
{
    public class PessoaService : BaseService<Pessoa, PessoaVm>, IPessoaService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public PessoaService(AppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
        {
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public override void Add(PessoaVm pessoa)
        {
            var dados = _mapper.Map<Pessoa>(pessoa);

            GetDbSet().Add(dados);
            AddPessoaComLogin(pessoa);

            _appDbContext.SaveChanges();

        }

        private void AddPessoaComLogin(PessoaVm pessoaVm)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaVm);
            pessoa.DataCadastro = DateTime.Now;
             
            _appDbContext.SaveChanges();

            var usuarioLogin = new UsuarioLogin
            {
                Id = Guid.NewGuid().ToString("D"),
                PessoaId = pessoa.Id,
                Usuario = pessoaVm.Usuario,
                Email = pessoaVm.Email,
                Senha = HashPassword(pessoaVm.Senha),
                DataCadastro = DateTime.Now,
            };

            _appDbContext.UsuariosLogins.Add(usuarioLogin);
            _appDbContext.SaveChanges();

        }

        public static string HashPassword(string password)
        {
            var hasher = new PasswordHasher<UsuarioLogin>();
            var usuarioDummy = new UsuarioLogin();  // Simula um "dummy", mas não é necessário para hash
            return hasher.HashPassword(usuarioDummy, password);
        }
    }
}