using CAD.Core.Negocio.Servicos.Interface;
using Newtonsoft.Json;
using System;
using System.Web;

namespace CAD.Core.Negocio.Servicos
{
    public class CacheServico : ICacheServico
    {
        public T ObterOuAtribuir<T>(string chave, Func<T> retorno) where T : class
        {
            T item;

            string objeto = HttpRuntime.Cache.Get(chave) as string;

            if (string.IsNullOrEmpty(objeto))
            {
                item = retorno();
                string strRetorno = JsonConvert.SerializeObject(item);

                HttpRuntime.Cache.Insert(chave, strRetorno, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
            }
            else
                item = JsonConvert.DeserializeObject<T>(objeto);

            return item;
        }
    }
}
