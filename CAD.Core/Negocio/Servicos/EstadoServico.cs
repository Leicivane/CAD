using CAD.Core.Negocio.DTO;
using CAD.Core.Negocio.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web.Configuration;

namespace CAD.Core.Negocio.Servicos
{
    public class EstadoServico
    {
        private readonly CacheServico _cacheServico;
        private readonly string _geoNameIdBrasil;
        private const string EstadosDoBrasil = "EstadoDoBrasil";

        public EstadoServico()
        {
            _geoNameIdBrasil = WebConfigurationManager.AppSettings["GeoNameIdBrasil"];
            _cacheServico = new CacheServico();
        }

        public ICollection<UFDTO> ListarEstados()
        {
            var estadosDoBrasil = _cacheServico.ObterOuAtribuir(EstadosDoBrasil, ListarEstadosBrasilGeoName);

            return estadosDoBrasil;
        }

        private ICollection<UFDTO> ListarEstadosBrasilGeoName()
        {
            try
            {
                byte[] dataEstados;
                var resultado = new List<UFDTO>();

                using (var webClient = new WebClient())
                {
                    var url = string.Format("http://www.geonames.org/childrenJSON?geonameId={0}",
                        _geoNameIdBrasil);
                    dataEstados = webClient.DownloadData(url);
                }

                if (dataEstados == null) return resultado;

                var stringEstados = Encoding.UTF8.GetString(dataEstados);
                var geonameResultado = JsonConvert.DeserializeObject<GeonameResultDTO>(stringEstados);

                foreach (var estadoGeoName in geonameResultado.geonames)
                {
                    var tmp = UFDTO.Converter(estadoGeoName);

                    resultado.Add(tmp);
                }

                return resultado;
            }
            catch (Exception)
            {
                throw new NegocioException("Erro ao listar os estados no WebService");
            }
        }
    }
}
