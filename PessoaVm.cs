using System;

namespace Modelos.Cadastro
{
    public class PessoaVm
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Crm { get; set; }
    }
}