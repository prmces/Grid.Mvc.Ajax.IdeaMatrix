using System.Web;
using System.Web.Optimization;
using Microsoft.Ajax.Utilities;

namespace Grid.Mvc.Demo
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            var siteJsBundle = new ScriptBundle("~/bundles/siteJs.js")
                .Include("~/Scripts/jquery-{version}.js", 
                "~/Scripts/URI.js",
                "~/Scripts/gridmvc.js", "~/Scripts/gridmvc-ext.js");
            bundles.Add(siteJsBundle);

            var bootstrapBundle = new ScriptBundle("~/Bundles/b.js").Include("~/Scripts/bootstrap.js");
            bundles.Add(bootstrapBundle);

            var gridJsDemo = new ScriptBundle("~/bundles/gridDemo.js")
               .Include("~/Scripts/gridmvcajax.demo.js");

            bundles.Add(gridJsDemo);
        }
    }
}