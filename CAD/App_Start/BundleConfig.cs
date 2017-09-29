using System.Web.Optimization;

namespace CAD
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css")
                .Include("~/Content/bootstrap.min.css")
                .Include("~/Content/bootstrap-table.min.css")
                .Include("~/Content/font-awesome.min.css")
                .Include("~/Content/bootstrap-datetimepicker.min.css")
                .Include("~/Content/bootstrap-cad-theme.css")
                .Include("~/Content/CAD/cad.css"));

            bundles.Add(new ScriptBundle("~/js")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.mask.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")
                .Include("~/Scripts/bootstrap.min.js")
                .Include("~/Scripts/bootstrap-table.min.js")
                .Include("~/Scripts/bootstrap-table-pt-BR.min.js")
                .Include("~/Scripts/moment.js")
                .Include("~/Scripts/moment-pt-br.js")
                .Include("~/Scripts/bootstrap-datetimepicker.min.js")
                .Include("~/Scripts/CAD/global.js")
                .Include("~/Scripts/CAD/dados.js"));
        }
    }
}