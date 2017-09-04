using Cad.Core.Negocio.DTO;
using Cad.Core.Negocio.Exception;
using Cad.Core.Util.Guard;

namespace Cad.Core.Negocio.Servico.Interface
{
    public interface IUsuarioServico
    {
        void Autenticar(UsuarioDTO usuario);
        void SolicitarMudancaSenha(UsuarioNovaSenhaDTO dto);
    }
}