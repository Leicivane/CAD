using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cad.Data.Entidades
{
    [Table("USUARIO_DEPARTAMENTO_TB")]
    public partial class UsuarioDepartamento
    {
        [Key, Column("ID_USUARIO_DEPARTAMENTO")]
        public int IdentificadorUsuarioDepartamento { get; set; }

        [Column("ID_USUARIO_FUNCAO")]
        public int IdentificadorUsuarioFuncao { get; set; }

        [Column("ID_USUARIO_SETOR")]
        public int IdentificadorUsuarioSetor { get; set; }

        [Column("ID_USUARIO")]
        public int IdentificadorUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
