using System.IO;
using System.Linq;
using System.Text;
using System.Web.Optimization;

namespace AngularInjector
{
    /// <summary> 
    /// Represents a <see cref="T:System.Web.Optimization.IBundleTransform" /> that automatically combines your AngularJS templates.
    /// </summary>
    public class NgTemplateTransform : IBundleTransform
    {
        internal static string ContentType;
        internal readonly static NgTemplateTransform Instance;

        static NgTemplateTransform()
        {
            ContentType = "text/javascript";
            Instance = new NgTemplateTransform();
        }

        /// <summary>
        /// Transforms the content in the <see cref="T:System.Web.Optimization.BundleResponse"/> object.
        /// </summary>
        /// <param name="context">The bundle context.</param>
        /// <param name="response">The bundle response.</param>
        public void Process(BundleContext context, BundleResponse response)
        {
            var bundle = context.BundleCollection.FirstOrDefault(b => b.Path == context.BundleVirtualPath) as NgTemplateBundle;
            if (bundle == null)
                return;

            var builder = new StringBuilder();
            builder.AppendFormat("angular.module('{0}')", bundle.Module);
            builder.AppendLine(".run(['$templateCache', function($templateCache) {");

            foreach (var file in response.Files.Select(bundleFile => bundleFile.VirtualFile).Where(file => !file.IsDirectory))
            {
                using (var reader = new StreamReader(file.Open()))
                {
                    var ngTemplate = string.Format("$templateCache.put('{0}', '{1}');", file.VirtualPath, Escape(reader.ReadToEnd()).Trim());
                    builder.AppendLine(ngTemplate);
                }
            }

            builder.AppendLine("}]);");

            response.Content = builder.ToString();
            response.ContentType = ContentType;
        }

        public string Escape(string input)
        {
            return input
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace("\\", "\\\\")
                .Replace("\'", "\\\'");

        }
    }
}