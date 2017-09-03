using CAD.Web.Infraestrutura.Interface;
using System.Web.Mvc;

namespace CAD.Web.Infraestrutura.MVC
{
    public class TempDataServico : ITempDataServico
    {
        private readonly TempDataDictionary _tempData;
        public TempDataServico(TempDataDictionary tempData)
        {
            _tempData = tempData;
        }
        public void Adicionar(string key, object valor)
        {
            _tempData[key] = valor;
        }

        public void Excluir(string key)
        {
            _tempData.Remove(key);
        }

        public object Buscar(string key)
        {
            var valor = _tempData[key];
            _tempData.Keep(key);
            return valor;
        }

        public T Buscar<T>(string key)
        {
            var valor = _tempData[key];
            _tempData.Keep(key);
            return (T)valor;
        }
    }
}