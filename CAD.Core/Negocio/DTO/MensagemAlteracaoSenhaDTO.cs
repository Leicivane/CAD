namespace CAD.Core.Negocio.DTO
{
    public class MensagemAlteracaoSenhaDTO
    {
        public DestinatarioMensagemDTO Destinatario { get; set; }
        public string Texto { get; set; }

        public string Assunto => "Altera��o de Email - CADSYS";
    }
}