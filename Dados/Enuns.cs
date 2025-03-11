using System.ComponentModel.DataAnnotations;

namespace Dados
{
    public enum TipoUsuarioEnum
    {
        [Display(Name = "Profissional")] Profissional = 0,
        [Display(Name = "Empresarial")] Empresarial = 1,
        [Display(Name = "Pessoal")] Pessoal = 2
    }
}
