namespace Cad.Data
{
    using System.ComponentModel.DataAnnotations;

    public partial class Endereco
    {
        [Key]
        public int IdentificadorEndereco { get; set; }

        public int IdentificadorMunicipio { get; set; }

        public int IdentificadorEstado { get; set; }

        public int IdentificadorPessoa { get; set; }

        [Required]
        [StringLength(255)]
        public string Logradouro { get; set; }

        [Required]
        [StringLength(8)]
        public string CEP { get; set; }

        [Required]
        [StringLength(255)]
        public string Bairro { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
