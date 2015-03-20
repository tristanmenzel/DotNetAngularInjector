using System.Web.Optimization;

namespace AngularInjector
{
    /*
     * Credit: Ismael Hamed
     * https://gist.github.com/ismaelhamed/307a9fc1025082f19574 * 
     * 
     * */

    /// <summary>
    /// Represents a bundle that does AngularJS Template minification.
    /// </summary>
    public class NgTemplateBundle : Bundle
    {
        /// <summary>
        /// Name of the angular.module to register the templates with. Default is 'myApp'.
        /// </summary>
        public string Module { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Web.Optimization.Bundle" /> class that takes a virtual path for the bundle.
        /// </summary>
        /// <param name="virtualPath">The virtual path for the bundle.</param>
        public NgTemplateBundle(string virtualPath)
            : this(virtualPath, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Web.Optimization.Bundle" /> class that takes virtual path and cdnPath for the bundle.
        /// </summary>
        /// <param name="virtualPath">The virtual path for the bundle.</param>
        /// <param name="cdnPath">The path of a Content Delivery Network (CDN).</param>
        public NgTemplateBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath, new NgTemplateTransform())
        {
            Module = "app";
        }
    }
}