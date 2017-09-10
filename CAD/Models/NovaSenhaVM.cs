using CAD.Core.Negocio.Mensagens;
using CAD.Core.Negocio.Servicos;
using CAD.Core.Util.Mapeador;
using System.ComponentModel.DataAnnotations;

namespace CAD.Models
{
    public class NovaSenhaVM
    {
        [Display(Name = "Senha")]
        [Required(ErrorMessageResourceName = "M003", ErrorMessageResourceType = typeof(Mensagem), AllowEmptyStrings = false)]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da Senha")]
        [Compare("Senha", ErrorMessageResourceName = "M013", ErrorMessageResourceType = typeof(Mensagem))]
        public string ConfirmacaoSenha { get; set; }

        public int IdentificadorUsuario { get; set; }

        public static UsuarioMudancaSenhaDTO Converter(NovaSenhaVM model)
        {
            var destino = Mapeador.MapearPara<NovaSenhaVM, UsuarioMudancaSenhaDTO>(model);

            return destino;
        }
    }
}