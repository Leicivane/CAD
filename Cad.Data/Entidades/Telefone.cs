using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cad.Data.Entidades
{
    [Table("TELEFONE_TB")]
    public partial class Telefone
    {
        [Key, Column("ID_TELEFONE")]
        public int IdentificadorTelefone { get; set; }

        [Column("ID_PESSOA")]
        public int IdentificadorPessoa { get; set; }

        [StringLength(10), Required, Column("PREFIXO_TELEFONE")]
        public string PrefixoTelefone { get; set; }

        [StringLength(50), Required, Column("NUMERO_TELEFONE")]
        public string NumeroTelefone { get; set; }

        [StringLength(255), Column("OBSERVACAO")]
        public string Observacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
