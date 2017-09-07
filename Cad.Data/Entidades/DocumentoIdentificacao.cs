using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cad.Data.Entidades
{
    [Table("DOCUMENTO_IDENTIFICACAO_TB")]
    public partial class DocumentoIdentificacao
    {
        [Key, Column("ID_DOCUMENTO_IDENTIFICACAO")]
        public int IdentificadorDocumentoIdentificacao { get; set; }

        [Column("ID_PESSOA")]
        public int IdentificadorPessoa { get; set; }
        
        [Column("CODIGO_TIPO_DOCUMENTO_IDENTIFICACAO")]
        public int CodigoTipoDocumentoIdentificacao { get; set; }

        [Column("NUMERO_DOCUMENTO_IDENTIFICACAO"), Required]
        public string NumeroDocumentoIdentificacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
