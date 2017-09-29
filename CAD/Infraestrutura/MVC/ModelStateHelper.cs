using System.Linq;
using System.Web.Mvc;

namespace CAD.Controllers
{
    public static class ModelStateHelper
    {
        public static object ObterErrosModelState(this ModelStateDictionary modelState)
        {
            var chaves = from modelstate in modelState.AsQueryable().Where(f => f.Value.Errors.Count > 0)
                select modelstate.Key;
            var listaErros = from modelstate in modelState.AsQueryable().Where(f => f.Value.Errors.Count > 0)
                select modelstate.Value.Errors.FirstOrDefault(a => !string.IsNullOrEmpty(a.ErrorMessage));

            listaErros = listaErros.Where(e => e != null);
            var resultado = new { HasErro = listaErros.Any(), chaves = chaves.ToList(), listaErros = listaErros.Select(a => a.ErrorMessage).ToList() };

            return resultado;
        }
    }
}