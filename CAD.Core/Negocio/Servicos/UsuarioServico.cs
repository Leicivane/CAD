using Cad.Data.Contexto;
using Cad.Data.Entidades;
using Cad.Data.Repositorios;
using CAD.Core.Negocio.DTO;
using CAD.Core.Negocio.Enums;
using CAD.Core.Negocio.Exceptions;
using CAD.Core.Negocio.Mensagens;
using CAD.Core.Negocio.Servicos.Interface;
using CAD.Core.Util.Extensao;
using CAD.Core.Util.Guard;
using System;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;

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
            if (usuario == null) throw new ArgumentNullException("usuario");

            var usuarioEncontrado = _repositorioUsuario
                .Obter(u =>
                u.Pessoa.DocumentosIdentificacao.Any(d => d.NumeroDocumentoIdentificacao == usuario.Login 
                        && d.CodigoTipoDocumentoIdentificacao == (int)TipoDocumento.CPF) 
                        && u.Pessoa.EmailPessoa == usuario.Email);

            if (usuarioEncontrado == null) return;

            usuarioEncontrado.AlteracaoSenha = true;
            _repositorioUsuario.Atualizar(usuarioEncontrado);
            _repositorioUsuario.SalvarAlteracoes();

            var request = HttpContext.Current.Request;
            var destinatario = new DestinatarioMensagemDTO
            {
                Nome = usuarioEncontrado.Pessoa.NomePessoa,
                Email = usuario.Email,
                Url = string.Format("{0}://{1}/Conta/NovaSenha/{2}",request.Url.Scheme,request.Url.Authority,
                usuarioEncontrado.IdentificadorUsuario.ToString().Criptografado())
            };
            var mensagem = _servicoEmail.ObterMensagemAlteracaoSenha(destinatario);
            _servicoEmail.EnviarMensagem(mensagem);
        }

        public bool VerificarSeDeveAtualizarSenha(int idUsuario)
        {
            var usuarioEncontrado = _repositorioUsuario.Obter(idUsuario);
            return !(usuarioEncontrado == null || usuarioEncontrado.AlteracaoSenha == false);
        }

        public void MudarSenha(UsuarioMudancaSenhaDTO usuarioMudancaSenhaDTO)
        {

            var podeMudarSenha = VerificarSeDeveAtualizarSenha(usuarioMudancaSenhaDTO.IdentificadorUsuario);

            if (!podeMudarSenha) throw new NegocioException(Mensagem.M014);

            var usuario = _repositorioUsuario.Obter(usuarioMudancaSenhaDTO.IdentificadorUsuario);

            if (usuario == null) throw new NegocioException(Mensagem.M015);

            var crypSenha = FormsAuthentication.HashPasswordForStoringInConfigFile(usuarioMudancaSenhaDTO.Senha, FormsAuthPasswordFormat.SHA1.ToString());
            usuario.Senha = crypSenha;
            usuario.AlteracaoSenha = false;

            _repositorioUsuario.Atualizar(usuario);
            _repositorioUsuario.SalvarAlteracoes();
        }

        public void AlterarSenha(UsuarioAlterarSenhaDTO alterarSenhaDTO)
        {
            var crypSenha = FormsAuthentication.HashPasswordForStoringInConfigFile(alterarSenhaDTO.Senha, FormsAuthPasswordFormat.SHA1.ToString());

            var usuarioEncontrado =
                _repositorioUsuario.Existe(
                    u => u.Senha == crypSenha && u.CodigoTipoUsuario == (int)TipoUsuario.Funcionario && u.Pessoa.DocumentosIdentificacao.Any(d => d.CodigoTipoDocumentoIdentificacao == (int)TipoDocumento.CPF && d.NumeroDocumentoIdentificacao == alterarSenhaDTO.Login));

            if (!usuarioEncontrado)
                throw new NegocioException(Mensagem.M001);

            var usuario =
                _repositorioUsuario.Obter(
                    u =>
                        u.Senha == crypSenha && u.CodigoTipoUsuario == (int) TipoUsuario.Funcionario &&
                        u.Pessoa.DocumentosIdentificacao.Any(
                            d =>
                                d.CodigoTipoDocumentoIdentificacao == (int) TipoDocumento.CPF &&
                                d.NumeroDocumentoIdentificacao == alterarSenhaDTO.Login));

            var crypNovaSenha = FormsAuthentication.HashPasswordForStoringInConfigFile(alterarSenhaDTO.NovaSenha, FormsAuthPasswordFormat.SHA1.ToString());
            usuario.Senha = crypNovaSenha;
            usuario.AlteracaoSenha = false;

            _repositorioUsuario.Atualizar(usuario);
            _repositorioUsuario.SalvarAlteracoes();
        }
    }
}