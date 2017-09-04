namespace Cad.Core.Negocio.Servico.Interface
{
    public class MensagemAlteracaoSenhaDTO
    {
        public DestinatarioMensagemDTO Destinatario { get; set; }
        public string Texto { get; set; }

        public string Assunto => "Altera��o de Email - CADSYS";
    }
}