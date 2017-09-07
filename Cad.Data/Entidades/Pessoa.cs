using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cad.Data.Entidades
{
    [Table("PESSOA_TB")]
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

        [Key, Column("ID_PESSOA")]
        public int IdentificadorPessoa { get; set; }

        [Column("CODIGO_TIPO_SEXO")]
        public int CodigoTipoSexo { get; set; }

        [StringLength(50), Required, Column("NOME_PESSOA")]
        public string NomePessoa { get; set; }

        [StringLength(200), Column("SOBRENOME_PESSOA")]
        public string SobrenomePessoa { get; set; }

        [StringLength(100), Column("EMAIL_PESSOA")]
        public string EmailPessoa { get; set; }

        [Column("DATA_NASCIMENTO")]
        public DateTime? DataNascimento { get; set; }

        [Column("DATA_REGISTRO")]
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
