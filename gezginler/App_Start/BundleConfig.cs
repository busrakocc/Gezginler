using System.Web;
using System.Web.Optimization;

namespace gezginler
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-transition.js",
                      "~/Scripts/bootstrap-carousel.js",
                      "~/Scripts/bootstrap-alert.js",
                      "~/Scripts/bootstrap-modal.js",
                      "~/Scripts/bootstrap-dropdown.js",
                      "~/Scripts/bootstrap-scrollspy.js",
                      "~/Scripts/bootstrap-tooltip.js",
                      "~/Scripts/bootstrap-popover.js",
                      "~/Scripts/bootstrap-button.js",
                      "~/Scripts/bootstrap-collapse.js",
                      "~/Scripts/bootstrap-typeahead.js"                     
                      ));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //         "~/Scripts/bootstrap.js",
            //         "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                     "~/Scripts/jquery-ui-1.8.18.custom.min.js",
                     "~/Scripts/jquery.smooth-scroll.min.js",
                     "~/Scripts/jquery.lightbox.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/bootstrap-responsive.css"));
        }
    }
}
