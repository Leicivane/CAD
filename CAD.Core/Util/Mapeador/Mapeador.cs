using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Cad.Core.Util.Mapeador
{
    public static class Mapeador
    {
        public static TResultado MapearPara<TOrigem, TResultado>(TOrigem origem)
            where TResultado : class
            where TOrigem : class
        {
            if (origem == null) return null;

            var tipoOrigem = origem.GetType();
            var tipoDestino = typeof(TResultado);

            var propriedadesOrigem = tipoOrigem.GetProperties();
            var propriedadesDestino = tipoDestino.GetProperties();

            var resultado = Activator.CreateInstance(typeof(TResultado));
            foreach (var propDestino in propriedadesDestino)
            {
                var isMapeada = false;
                if (propriedadesOrigem.Any(p => string.Compare(p.Name, propDestino.Name, StringComparison.InvariantCultureIgnoreCase) == 0 &&
                    p.PropertyType.Name == propDestino.PropertyType.Name))
                {
                    var propriedadeEncontradaNaOrigem =
                        propriedadesOrigem.First(
                            p => string.Compare(p.Name, propDestino.Name, StringComparison.InvariantCultureIgnoreCase) == 0 && p.GetType() == propDestino.GetType());
                    var propriedadeEncontradaNoDestino =
                        propriedadesDestino.First(
                            p => string.Compare(p.Name, propDestino.Name, StringComparison.InvariantCultureIgnoreCase) == 0 && p.GetType() == propDestino.GetType());
                    var podeSerEscrita = propriedadeEncontradaNoDestino.CanWrite &&
                                         (!propDestino.PropertyType.IsGenericType || propDestino.PropertyType.GetGenericTypeDefinition() != typeof(IEnumerable<>) &&
                                          propDestino.PropertyType.IsGenericType &&
                                          propDestino.PropertyType.GetGenericTypeDefinition() != typeof(List<>));
                    if (podeSerEscrita)
                    {
                        var valor = origem.GetType()
                            .GetProperty(propriedadeEncontradaNaOrigem.Name)
                            .GetValue(origem, null);
                        propDestino.SetValue(resultado, valor, null);
                        isMapeada = true;
                    }
                }
#if(DEBUG)
                if (!isMapeada)
                    Debug.WriteLine("ATENÇÃO: Propriedade {0} do tipo {1} não mapeada", propDestino.Name, tipoDestino.Name);
#endif
            }

            return resultado as TResultado;
        }
    }
}

