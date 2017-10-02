using CAD.Core.Util.Guard;

namespace CAD.Core.Negocio.DTO
{
    public class UFDTO
    {
        public static UFDTO Converter(GeonameLocalizacaoDTO estadoGeoName)
        {
            Guard.IsNotNull(estadoGeoName, "estadoGeoName");

            var resultado = new UFDTO
            {
                Nome = estadoGeoName.Name,
                Id = estadoGeoName.GeonameId
            };

            return resultado;
        }

        public string Nome { get; set; }

        public int Id { get; set; }
    }
}