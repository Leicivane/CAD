using CAD.Core.Negocio.Mensagens;
using CAD.Core.Negocio.Servicos.Interface;
using CAD.Core.Util.Mapeador;
using CAD.Infraestrutura.MVC.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CAD.Models
{
    public class AlterarSenhaVM
    {
        [Display(Name = "Login")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        [CPF(ErrorMessageResourceName = "M011", ErrorMessageResourceType = typeof(Mensagem))]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Senha { get; set; }

        public string LoginFormatado => Login.Replace(".", "").Replace("-", "");
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]

        [Display(Name = "Nova Senha")]
        public string NovaSenha { get; set; }

        [Display(Name = "Confirmação da Senha")]
        [Compare("NovaSenha", ErrorMessageResourceName = "M013", ErrorMessageResourceType = typeof(Mensagem))]
        public string ConfirmacaoSenha { get; set; }

        public static UsuarioAlterarSenhaDTO Converter(AlterarSenhaVM model)
        {
            var destino = Mapeador.MapearPara<AlterarSenhaVM, UsuarioAlterarSenhaDTO>(model);
            destino.Login = model.LoginFormatado;

            return destino;
        }
    }
}