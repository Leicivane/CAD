namespace Cad.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Usuarios = new HashSet<UsuarioSetor>();
        }

        [Key]
        public int IdentificadorUsuario { get; set; }

        public int IdentificadorPessoa { get; set; }

        public int CodigoTipoUsuario { get; set; }

        public byte Desativado { get; set; }

        [StringLength(255)]
        public string DescricaoDesativacao { get; set; }

        [Required]
        [StringLength(15)]
        public string Senha { get; set; }

        public byte AlteracaoSenha { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioSetor> Usuarios { get; set; }
    }
}
