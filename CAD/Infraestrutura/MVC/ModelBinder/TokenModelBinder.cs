using System;
using System.Web.Mvc;
using CAD.Core.Negocio.Exceptions;
using CAD.Core.Util.Extensao;

namespace CAD.Infraestrutura.MVC.ModelBinder
{
    public class TokenModelBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            const string id = "id";
            var contemId = bindingContext.ValueProvider.ContainsPrefix(id);

            if (!contemId) throw new NegocioException("Sua senha já foi previamente gerada");

            var tokenResult = bindingContext.ValueProvider.GetValue(id);

            var idDescriptografado = tokenResult.RawValue.ToString().Descriptografado();

            return Convert.ToInt32(idDescriptografado);
        }
    }
}