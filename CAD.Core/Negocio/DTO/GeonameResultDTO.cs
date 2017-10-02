using CAD.Core.Negocio.DTO;
using System.Collections.Generic;

namespace CAD.Core.Negocio.Servicos
{
    public class GeonameResultDTO
    {
        public int totalResultsCount { get; set; }
        public List<GeonameLocalizacaoDTO> geonames { get; set; }
    }
}