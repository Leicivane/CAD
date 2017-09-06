namespace Cad.Data
{
    using System.ComponentModel.DataAnnotations;

    public partial class Telefone
    {
        [Key]
        public int IdentificadorTelefone { get; set; }

        public int? IdentificadorPessoa { get; set; }

        [Required]
        [StringLength(10)]
        public string PrefixoTelefone { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroTelefone { get; set; }

        [StringLength(255)]
        public string Observacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
