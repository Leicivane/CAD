using Cad.Data.Contexto;
using Cad.Data.Entidades;
using Cad.Data.Repositorios;
using CAD.Core.Negocio.DTO;
using CAD.Core.Negocio.Exceptions;
using CAD.Core.Negocio.Mensagens;
using CAD.Core.Negocio.Servicos.Interface;
using CAD.Core.Util.Guard;
using System.Linq;
using System.Web.Configuration;
using System.Web.Security;
using CAD.Core.Negocio.Enums;

namespace CAD.Core.Negocio.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly RepositorioAtualizavel<Usuario> _repositorioUsuario;
        private readonly EmailServico _servicoEmail;

        public UsuarioServico()
        {
            _repositorioUsuario = new RepositorioAtualizavel<Usuario>(new CADContext());
            _servicoEmail = new EmailServico();
        }

        public void Autenticar(UsuarioDTO usuario)
        {
            Guard.IsNotNull(usuario);

            var crypSenha = FormsAuthentication.HashPasswordForStoringInConfigFile(usuario.Senha, FormsAuthPasswordFormat.SHA1.ToString());

            var usuarioEncontrado =
                _repositorioUsuario.Existe(
                    u => u.Senha == crypSenha && u.CodigoTipoUsuario == (int)TipoUsuario.Funcionario && u.Pessoa.DocumentosIdentificacao.Any(d => d.CodigoTipoDocumentoIdentificacao == (int)TipoDocumento.CPF && d.NumeroDocumentoIdentificacao == usuario.Login));

            if (!usuarioEncontrado)
                throw new NegocioException(Mensagem.M001);

            FormsAuthentication.SetAuthCookie(usuario.Login, usuario.LembrarSenha);
        }

        public void SolicitarMudancaSenha(UsuarioNovaSenhaDTO usuario)
        {
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