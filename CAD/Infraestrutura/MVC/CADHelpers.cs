using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace CAD.Infraestrutura.MVC
{
    public static class CADHelpers
    {

        public static MvcHtmlString DropdownUfFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return new MvcHtmlString(string.Empty);
        }

    }
}