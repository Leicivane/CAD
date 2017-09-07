using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cad.Data.Entidades
{
    [Table("ENDERECO_TB")]
    public partial class Endereco
    {
        [Key, Column("ID_ENDERECO")]
        public int IdentificadorEndereco { get; set; }

        [Column("ID_MUNICIPIO")]
        public int IdentificadorMunicipio { get; set; }

        [Column("ID_ESTADO")]
        public int IdentificadorEstado { get; set; }

        [Column("ID_PESSOA")]
        public int IdentificadorPessoa { get; set; }

        [StringLength(255), Required, Column("LOGRADOURO")]
        public string Logradouro { get; set; }

        [StringLength(8), Required, Column("CEP")]
        public string CEP { get; set; }

        [StringLength(255), Column("BAIRRO"), Required]
        public string Bairro { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
