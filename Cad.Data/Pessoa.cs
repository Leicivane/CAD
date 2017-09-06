namespace Cad.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            DocumentosIdentificacao = new HashSet<DocumentoIdentificacao>();
            Enderecos = new HashSet<Endereco>();
            OrdemsServico = new HashSet<OrdemServico>();
            Telefones = new HashSet<Telefone>();
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int IdentificadorPessoa { get; set; }

        public int CodigoTipoSexo { get; set; }

        [Required]
        [StringLength(50)]
        public string NomePessoa { get; set; }

        [StringLength(200)]
        public string SobreNomePessoa { get; set; }

        [StringLength(100)]
        public string EmailPessoa { get; set; }

        public DateTime? DataNascimento { get; set; }

        public DateTime DataRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentoIdentificacao> DocumentosIdentificacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Endereco> Enderecos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdemServico> OrdemsServico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Telefone> Telefones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
