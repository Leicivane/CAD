using System.ComponentModel;

namespace CAD.Core.Negocio.Enums
{
    public enum TipoDocumento
    {
        [Description("Cadastro de Pessoa Física")]
        CPF,
        [Description("Registro Geral")]
        RG
    }
}