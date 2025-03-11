using Dados;
using Models;
using System.ComponentModel.DataAnnotations;

namespace Modelos.Models.Cadastro
{
    public class PessoaVm : BaseVm
    {
        public string Nome { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve ter 11 dígitos")]
        public string Cpf { get; set; }

        [StringLength(20, ErrorMessage = "O campo \"{0}\" não deve ultrapassar o tamanho de \"{1}\" caracteres")]
        public string? Rg { get; set; }

        [StringLength(20, ErrorMessage = "O campo \"{0}\" não deve ultrapassar o tamanho de \"{1}\" caracteres")]
        public string? Cnpj { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Crm { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}