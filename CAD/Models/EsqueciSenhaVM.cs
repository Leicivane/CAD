using CAD.Core.Negocio.Mensagens;
using CAD.Infraestrutura.MVC;
using System.ComponentModel.DataAnnotations;
using CAD.Core.Negocio.DTO;
using CAD.Core.Negocio.Servicos.Interface;
using CAD.Core.Util.Guard;
using CAD.Core.Util.Mapeador;

namespace CAD.Models
{
    public class EsqueciSenhaVM
    {
        [Display(Name = "Login")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        [CPF(ErrorMessageResourceName = "M011", ErrorMessageResourceType = typeof(Mensagem))]
        public string Login { get; set; }

        public string LoginFormatado => Login.Replace(".", "").Replace("-", "");

        [Display(Name = "Lembrar a senha?")]
        public bool LembrarSenha { get; set; } 

        [Display(Name = "Email")]
        [Email(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem))]
        [Required(ErrorMessageResourceName = "M005", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Email { get; set; }

        public static UsuarioNovaSenhaDTO Converter(EsqueciSenhaVM model)
        {
            Guard.IsNotNull(model);

            var destino = Mapeador.MapearPara<EsqueciSenhaVM, UsuarioNovaSenhaDTO>(model);
            destino.Login = model.LoginFormatado;
            return destino;
        }
    }
}