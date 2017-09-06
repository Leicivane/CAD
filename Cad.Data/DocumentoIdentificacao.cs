namespace Cad.Data
{
    using System.ComponentModel.DataAnnotations;

    public partial class DocumentoIdentificacao
    {
        public int IdentificadorPessoa { get; set; }

        [Key]
        public int IdentificadorDocumentoIdentificacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
