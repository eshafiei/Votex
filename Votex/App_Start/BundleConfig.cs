using System.Web.Optimization;

namespace Votex
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/datatables-1.10.12/media/js/jquery.datatables.js",
                        "~/Scripts/datatables-1.10.12/media/js/datatables.bootstrap.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/Scripts/appScripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-spacelab.css",
                      "~/Content/DataTables-1.10.12/media/css/datatables.bootstrap.css",
                      "~/Content/themes/base/base.css",
                      "~/Content/themes/base/theme.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/sidebar.css",
                      "~/Content/site.css"));
        }
    }
}
