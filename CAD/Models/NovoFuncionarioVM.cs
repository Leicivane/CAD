using CAD.Core.Negocio.Mensagens;
using System.ComponentModel.DataAnnotations;

namespace CAD.Models
{
    public class NovoFuncionarioVM
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Nome { get; set; }
        [Display(Name = "Sobrenome")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Sobrenome { get; set; }

        public string RG { get; set; }
        public string CPF { get; set; }
    }
}