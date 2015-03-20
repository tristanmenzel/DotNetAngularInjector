using System.Web.Optimization;

namespace AngularInjector
{
    public class NgBundle : Bundle
    {
        public NgBundle(string virtualPath)
            : base(virtualPath, new NgInjectTransform(), new JsMinify())
        {
        }

        public NgBundle(string virtualPath, string cdnPath) : base(virtualPath, cdnPath, new NgInjectTransform(), new JsMinify())
        {
        }
    }
}