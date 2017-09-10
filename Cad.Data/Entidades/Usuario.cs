using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cad.Data.Entidades
{
    [Table("USUARIO_TB")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            UsuariosDepartamento = new HashSet<UsuarioDepartamento>();
        }

        [Key,Column("ID_USUARIO")]
        public int IdentificadorUsuario { get; set; }

        [Column("ID_PESSOA")]
        public int IdentificadorPessoa { get; set; }

        [Column("CODIGO_TIPO_USUARIO")]
        public int CodigoTipoUsuario { get; set; }

        [Column("DESATIVADO")]
        public bool Desativado { get; set; }

        [StringLength(255), Column("DESCRICAO_DESATIVACAO")]
        public string DescricaoDesativacao { get; set; }

        [StringLength(40), Required, Column("SENHA")]
        public string Senha { get; set; }

        [Column("ALTERACAO_SENHA")]
        public bool AlteracaoSenha { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioDepartamento> UsuariosDepartamento { get; set; }
    }
}
