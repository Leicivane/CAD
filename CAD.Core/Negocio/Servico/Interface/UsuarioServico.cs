using System;
using Cad.Core.Negocio.DTO;

namespace Cad.Core.Negocio.Servico.Interface
{
    public class UsuarioServico : IUsuarioServico
    {
        //private readonly RepositorioAtualizavel<Usuario> _repositorioUsuario;
        //private readonly EmailServico _servicoEmail;

        public UsuarioServico()
        {
            //_repositorioUsuario = new RepositorioAtualizavel<Usuario>(context);
            //_servicoEmail = new EmailServico();
        }

        public void Autenticar(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
            //Guard.IsNotNull(usuario);

            //var crypSenha = FormsAuthentication.HashPasswordForStoringInConfigFile(usuario.Senha, FormsAuthPasswordFormat.SHA1.ToString());

            //var usuarioEncontrado = _repositorioUsuario.Existe(u => u.Senha == crypSenha && u.Login == usuario.Login);

            //if (!usuarioEncontrado)
            //    throw new NegocioException("Usu�rio inv�lido ou n�o encontrado");

            //FormsAuthentication.SetAuthCookie(usuario.Login, usuario.LembrarSenha);
        }

        public void SolicitarMudancaSenha(UsuarioNovaSenhaDTO usuario)
        {
            throw new NotImplementedException();
            //if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            //var usuarioEncontrado = _repositorioUsuario.Obter(u => u.Login == usuario.Login);
            //if (usuarioEncontrado == null) return;

            //usuarioEncontrado.HasAlteracaoSenha = true;
            //_repositorioUsuario.Atualizar(usuarioEncontrado);
            //_repositorioUsuario.SalvarAlteracoes();


            //var d = new DestinatarioMensagemDTO()
            //{
            //    Nome = usuarioEncontrado.Login,
            //    Email = usuario.Email
            //};
            //var mensagem = _servicoEmail.ObterMensagemAlteracaoSenha(d);
            //_servicoEmail.EnviarMensagem(mensagem);
        }
    }
}