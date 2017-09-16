using CAD.Core.Negocio.DTO;

namespace CAD.Core.Negocio.Servicos.Interface
{
    public interface IUsuarioServico
    {
        void Autenticar(UsuarioDTO usuario);
        void SolicitarMudancaSenha(UsuarioNovaSenhaDTO dto);
        bool VerificarSeDeveAtualizarSenha(int idUsuario);
        void MudarSenha(UsuarioMudancaSenhaDTO usuarioMudancaSenha);
        void AlterarSenha(UsuarioAlterarSenhaDTO alterarSenhaDTO);
    }
}