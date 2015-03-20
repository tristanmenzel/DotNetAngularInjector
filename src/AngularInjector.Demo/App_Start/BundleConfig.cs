using System.Web.Optimization;

namespace AngularInjector.Demo
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/vendor")
                .Include("~/scripts/angular.js")
                .Include("~/scripts/angular-ui-router.js"));

            bundles.Add(new NgBundle("~/js/ng")
                .IncludeDirectory("~/app/js/", "*.module.js", true)
                .IncludeDirectory("~/app/js", "*.js", true));


            bundles.Add(new NgTemplateBundle("~/js/templates")
                .IncludeDirectory("~/app/templates", "*.tpl.html", true));
        }
    }
}