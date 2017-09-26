using System;

namespace CAD.Models
{
    public class TelefoneVM
    {
        public TipoTelefone TipoTelefone { get; set; }

        public string DDD { get; set; }
        public string Numero { get; set; }
        public DateTime HorarioDeContato { get; set; }
    }
}