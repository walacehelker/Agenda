using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class BaseVm
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public string? Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Excluido { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
