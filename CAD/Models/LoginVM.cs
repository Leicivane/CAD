using CAD.Core.Negocio.Mensagens;
using CAD.Infraestrutura.MVC;
using System.ComponentModel.DataAnnotations;
using CAD.Core.Negocio.DTO;
using CAD.Core.Util.Guard;
using CAD.Core.Util.Mapeador;
using CAD.Infraestrutura.MVC.Attributes;

namespace CAD.Models
{
    public class LoginVM
    {
        [Display(Name = "Login")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        [CPF(ErrorMessageResourceName = "M011", ErrorMessageResourceType = typeof(Mensagem))]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Senha { get; set; }

        public string LoginFormatado => Login.Replace(".", "").Replace("-", "");

        [Display(Name = "Lembrar a senha")]
        public bool LembrarSenha { get; set; }

        public static UsuarioDTO Converter(LoginVM model)
        {
            Guard.IsNotNull(model);

            var destino = Mapeador.MapearPara<LoginVM, UsuarioDTO>(model);
            destino.Login = model.LoginFormatado;
            return destino;
        }
    }
}