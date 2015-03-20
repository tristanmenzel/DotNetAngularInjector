using System.IO;
using System.Linq;
using System.Text;
using System.Web.Optimization;

namespace AngularInjector
{
    public class NgInjectTransform : IBundleTransform
    {
        internal static string ContentType;
        internal readonly static NgInjectTransform Instance;
        private static Injector _injector;

        static NgInjectTransform()
        {
            ContentType = "text/javascript";
            Instance = new NgInjectTransform();
            _injector = new Injector();
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            var bundle = context.BundleCollection.FirstOrDefault(b => b.Path == context.BundleVirtualPath) as NgBundle;
            if (bundle == null)
                return;

            var builder = new StringBuilder();

            foreach (var file in response.Files.Select(bundleFile => bundleFile.VirtualFile).Where(file => !file.IsDirectory))
            {
                using (var reader = new StreamReader(file.Open()))
                {
                    var script = reader.ReadToEnd();
                    builder.AppendLine(_injector.Inject(script));
                }
            }

            response.Content = builder.ToString();
            response.ContentType = ContentType;
        }

    }
}