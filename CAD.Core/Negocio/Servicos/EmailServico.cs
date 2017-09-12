using CAD.Core.Negocio.DTO;
using CAD.Core.Negocio.Recursos;
using System;
using System.Net;
using System.Net.Mail;

namespace CAD.Core.Negocio.Servicos
{
    public class EmailServico
    {
        private readonly RemetenteMensagemDTO _remetenteMensagem;

        public EmailServico() : this(
            new RemetenteMensagemDTO
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
                Texto = Email.EsqueciSenha.Replace("{NOME}", destinatario.Nome).Replace("{URL}", destinatario.Url),
                Destinatario = destinatario,
            };

            return msg;
        }

        public void EnviarMensagem(MensagemAlteracaoSenhaDTO mensagem)
        {
            if (mensagem == null) throw new ArgumentNullException("mensagem");

            var from = new MailAddress(_remetenteMensagem.Email, _remetenteMensagem.Nome);
            var to = new MailAddress(mensagem.Destinatario.Email, mensagem.Destinatario.Nome);
            var mail = new MailMessage(from, to);
            var client = new SmtpClient
            {
                Port = 587,
                Host = "smtp.gmail.com",
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("leicivanemoura@gmail.com", "Maria_Eduarda")

            };
            mail.Subject = mensagem.Assunto;
            mail.Body = mensagem.Texto;
            mail.IsBodyHtml = true;
            client.Send(mail);

        }
    }
}