using System.Web;
using System.Web.Optimization;

namespace RasiMarket
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/masterpage").Include(
                      "~/Scripts/vendor/vendor.js", "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/vendor/modernizr.js"));

            bundles.Add(new StyleBundle("~/Content/maincss").Include(
                      "~/Content/style.css",
                      "~/Content/vendor.css"));
        }
    }
}
