using System;
using Dados;

namespace Dados.Cadastro
{
    public class UsuarioLogin : Base
    {
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public string PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
