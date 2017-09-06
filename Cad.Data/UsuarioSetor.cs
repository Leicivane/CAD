namespace Cad.Data
{
    using System.ComponentModel.DataAnnotations;

    public partial class UsuarioSetor
    {
        [Key]
        public int IdentificadorUsuarioSetor { get; set; }

        public int? IdentificadorFuncaoFuncionario { get; set; }

        public int? IdentificadorSetorFuncionario { get; set; }

        public int? IdentificadorUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
