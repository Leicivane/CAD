using CAD.Core.Negocio.Servicos;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CAD.Infraestrutura.MVC.Helpers
{
    public static class CADHelpers
    {
        static CADHelpers()
        {
            EstadosServico = new EstadoServico();
        }

        public static EstadoServico EstadosServico { get; set; }

        public static MvcHtmlString DropdownUfFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var id = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var ufs = EstadosServico.ListarEstadosDoBrasil();
            if (ufs == null) return MvcHtmlString.Empty;

            var selectListItens = ufs.Select(u => new SelectListItem
            {
                Text = u.Nome,
                Value = u.Id.ToString()
            });

            return htmlHelper.DropDownListFor(expression, selectListItens, "Selecione", htmlAttributes);
        }


        public static HtmlString ExportEnums<T>(this HtmlHelper helper) where T : struct
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine("if(!window.CADEnums) CADEnums= {};");
            var enums = Enum.GetValues(typeof(T)).Cast<int>().ToDictionary(x => Enum.GetName(typeof(T), x), y => y);
            sb.AppendLine("CADEnums." + typeof(T).Name + " = " + System.Web.Helpers.Json.Encode(enums) + " ;");
            sb.AppendLine("</script>");
            return new HtmlString(sb.ToString());
        }

        public static HtmlString ExportUrls(this HtmlHelper helper)
        {

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("<script type=\"text/javascript\">");
            sb.AppendLine("if(!window.CADUrl) CADUrl= {};");

            Assembly asm = Assembly.GetAssembly(typeof(MvcApplication));
            var controllersActionList = asm.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList()
                    .GroupBy(x => x.Controller).Select(x => new
                    {
                        ControllerName = x.Key.ToLowerInvariant().Replace("controller", string.Empty),
                        Actions = x.Select(e => e.Action).Distinct().ToList()
                    });

            foreach (var controller in controllersActionList)
            {

                sb.AppendLine(string.Format("if(!window.CADUrl.{0}) CADUrl.{0}= {{}};", controller.ControllerName));
                foreach (var action in controller.Actions)
                {
                    sb.AppendLine(string.Format("CADUrl.{0}.{1} = \"{2}\" ;", controller.ControllerName, action.ToLowerInvariant(), urlHelper.Action(action, controller.ControllerName).ToLowerInvariant()));
                }
            }
            sb.AppendLine("</script>");
            return new HtmlString(sb.ToString());
        }
    }
}