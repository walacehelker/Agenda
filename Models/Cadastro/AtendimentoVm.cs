using AutoMapper.Configuration.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Cadastro
{
    public class AtendimentoVm : BaseVm
    {
        [DisplayName("Descricao")]
        [Required(ErrorMessage = "Campo obrigatório: {0}")]
        [StringLength(400, ErrorMessage = "O campo \"{0}\" não deve ultrapassar o tamanho de \"{1}\" caracteres")]
        public string Descricao { get; set; }

        [DisplayName("Data")]
        [DataType(DataType.Date, ErrorMessage = "{0} em formato inválido")]
        [Required(ErrorMessage = "Campo obrigatório: {0}")]
        public DateTime DataAtendimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: {0}")]
        public string PessoaId { get; set; }

        [Ignore]
        public virtual string? PessoaNome { get; set; }

        [Ignore]
        public virtual string? TipoAtendimentoNome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: {0}")]
        public string TipoAtendimentoId { get; set; }
    }

    public class AtendimentoCadVm : BaseVm
    {
        [DisplayName("Descricao")]
        [Required(ErrorMessage = "Campo obrigatório: {0}")]
        [StringLength(400, ErrorMessage = "O campo \"{0}\" não deve ultrapassar o tamanho de \"{1}\" caracteres")]
        public string Descricao { get; set; }

        [DisplayName("Data")]
        [DataType(DataType.Date, ErrorMessage = "{0} em formato inválido")]
        [Required(ErrorMessage = "Campo obrigatório: {0}")]
        public DateTime DataAtendimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: {0}")]
        public string PessoaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório: {0}")]
        public string TipoAtendimentoId { get; set; }
    }
}
