# DotNetAngularInjector
Some custom bundles to allow better minification and bundling of angular resources when using asp.net bundling and optimization.

##Install
_When I get around to putting this on nuget.org .... in the mean time you can grab the nupkg from the /dist/ folder._
```powershell
Install-Package AngularInjector
```

##Usage
**Create bundles**
```c#
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
```
**Reference bundles**
```razor
@Scripts.Render("~/js/vendor")
@Scripts.Render("~/js/ng")
<script src="@Scripts.Url("~/js/templates")"></script>
```
_Note: If you use @Scripts.Render on your templates and have optimizations turned off it will render a `<script />` 
link for each html fill which is probably not what you want. `@Scripts.Url` will mean you always get the bundled file regardless
of the optimizations setting value._

**Annotate components**

```js
angular.module('app')
    .controller('MyController', MyController);
/*inject(MyController)*/
function MyController($http, $stateParams){
    var vm = this;
    vm.message = 'Hello world';
}
```

