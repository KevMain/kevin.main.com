using System.Web;
using System.Web.Optimization;

namespace kevin_main.com
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Assets/Styles").Include(
                      "~/Assets/Styles/bootstrap.css",
                      "~/Assets/Styles/style.css",
                      "~/Assets/Styles/site.css"));

            bundles.Add(new ScriptBundle("~/Assets/Scripts/ltIE9").Include(
                      "~/Assets/Bootstrap/js/html5shiv.min.js",
                      "~/Assets/Bootstrap/js/respond.min.js"));

            bundles.Add(new ScriptBundle("~/Assets/Scripts/modernizr").Include(
                      "~/Assets/Scripts/modernizr.custom.js"));
        }
    }
}
