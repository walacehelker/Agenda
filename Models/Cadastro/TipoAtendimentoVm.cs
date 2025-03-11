using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models.Cadastro
{
    public class TipoAtendimentoVm : BaseVm
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "Campo obrigatório: {0}")]
        [StringLength(75, ErrorMessage = "O campo \"{0}\" não deve ultrapassar o tamanho de \"{1}\" caracteres")]
        public string Nome { get; set; }

        [DisplayName("Descricao")]
        [Required(ErrorMessage = "Campo obrigatório: {0}")]
        [StringLength(400, ErrorMessage = "O campo \"{0}\" não deve ultrapassar o tamanho de \"{1}\" caracteres")]
        public string Descricao { get; set; }
    }
}
