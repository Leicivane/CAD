using Cad.Core.Negocio.DTO;
using Cad.Core.Negocio.Mensagem;
using Cad.Core.Util.Guard;
using Cad.Core.Util.Mapeador;
using CAD.Web.Infraestrutura.MVC;
using System.ComponentModel.DataAnnotations;

namespace CAD.Web.Model
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