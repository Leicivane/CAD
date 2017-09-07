using CAD.Core.Negocio.DTO;
using CAD.Core.Negocio.Recursos;
using CAD.Core.Negocio.Servicos.Interface;
using System;
using System.Net.Mail;

namespace CAD.Core.Negocio.Servicos
{
    public class EmailServico
    {
        private readonly RemetenteMensagemDTO _remetenteMensagem;

        public EmailServico() : this(new RemetenteMensagemDTO
        {
            Email = "meajuda@cadsys.com.br",
            Nome = "Me Ajuda - CadSys"
        })
        {

        }

        public EmailServico(RemetenteMensagemDTO remetenteMensagem)
        {
            _remetenteMensagem = remetenteMensagem;
        }

        public MensagemAlteracaoSenhaDTO ObterMensagemAlteracaoSenha(DestinatarioMensagemDTO destinatario)
        {
            var msg = new MensagemAlteracaoSenhaDTO
            {
                Texto = Email.EsqueciSenha,
                Destinatario = destinatario
            };

            return msg;
        }

        public void EnviarMensagem(MensagemAlteracaoSenhaDTO mensagem)
        {
            if (mensagem == null) throw new ArgumentNullException(nameof(mensagem));

            var from = new MailAddress(_remetenteMensagem.Email, _remetenteMensagem.Nome);
            var to = new MailAddress(mensagem.Destinatario.Email, mensagem.Destinatario.Nome);
            var mail = new MailMessage(from, to);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "localhost"
            };
            mail.Subject = mensagem.Assunto;
            mail.Body = mensagem.Texto;
            mail.IsBodyHtml = true;
            client.Send(mail);

        }
    }
}