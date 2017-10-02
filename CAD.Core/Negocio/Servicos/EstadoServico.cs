using CAD.Core.Negocio.DTO;
using CAD.Core.Negocio.Exceptions;
using CAD.Core.Util.Guard;
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

        public ICollection<UFDTO> ListarEstadosDoBrasil()
        {
            var estadosDoBrasil = _cacheServico.ObterOuAtribuir(EstadosDoBrasil, ListarEstadosBrasilGeoName);

            return estadosDoBrasil;
        }

        private ICollection<UFDTO> ListarEstadosBrasilGeoName()
        {
            try
            {
                var dataEstados = ObterGeonameDataBrasil();
                var resultado = new List<UFDTO>();
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

        public ICollection<CidadeDTO> ListarCidadesDoEstado(string estadoId)
        {
            Guard.IsNotNull(estadoId, "estadoId");
            var cidadesDoEstado = string.Format("CidadesDoEstado_{0}", estadoId);
            var cidades = _cacheServico.ObterOuAtribuir(cidadesDoEstado, () => ListarCidadesEstadoGeoName(estadoId));

            return cidades;
        }

        private ICollection<CidadeDTO> ListarCidadesEstadoGeoName(string estadoId)
        {
            try
            {
                var resultado = new List<CidadeDTO>();
                var dataCidades = ObterGeonameData(estadoId);
                if (dataCidades == null) return resultado;

                var stringCidades = Encoding.UTF8.GetString(dataCidades);
                var geoNameCidades = JsonConvert.DeserializeObject<GeonameResultDTO>(stringCidades);


                foreach (var estadoGeoName in geoNameCidades.geonames)
                {
                    var tmp = CidadeDTO.Converter(estadoGeoName);

                    resultado.Add(tmp);
                }

                return resultado;

            }
            catch (Exception)
            {
                throw new NegocioException(string.Format("Erro ao listar as cidades do estado {0}", estadoId));
            }
        }

        private byte[] ObterGeonameDataBrasil()
        {
            return ObterGeonameData(_geoNameIdBrasil);
        }

        private byte[] ObterGeonameData(string geoNameId)
        {
            byte[] dataEstados;

            using (var webClient = new WebClient())
            {
                var url = string.Format("http://www.geonames.org/childrenJSON?geonameId={0}",
                    geoNameId);
                dataEstados = webClient.DownloadData(url);
            }
            return dataEstados;
        }
    }

    public class CidadeDTO
    {
        public string Nome { get; set; }

        public int Id { get; set; }

        public static CidadeDTO Converter(GeonameLocalizacaoDTO estadoGeoName)
        {
            Guard.IsNotNull(estadoGeoName, "estadoGeoName");

            var resultado = new CidadeDTO
            {
                Nome = estadoGeoName.Name,
                Id = estadoGeoName.GeonameId
            };

            return resultado;
        }
    }
}
