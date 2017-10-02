using System;

namespace CAD.Core.Negocio.Servicos.Interface
{
    interface ICacheServico
    {
        T ObterOuAtribuir<T>(string chave, Func<T> retorno) where T : class;
    }
}
