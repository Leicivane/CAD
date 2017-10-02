using CAD.Core.Negocio.Enums;

namespace CAD.Models
{
    public class TelefoneVM
    {
        public TipoTelefone TipoTelefone { get; set; }

        public string DDD { get; set; }
        public string Numero { get; set; }
        public string HorarioDeContato { get; set; }
    }
}