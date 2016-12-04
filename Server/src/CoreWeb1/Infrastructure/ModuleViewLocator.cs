using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CoreWeb1.Infrastructure
{
    /// <summary>
    /// Support for the Modules/Domain/Views
    /// http://hossambarakat.net/2016/02/16/asp-net-core-mvc-feature-folders/
    /// Not being used as this app is small. would use in a production app.
    /// </summary>
    public class ModuleViewLocator : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(ModuleViewLocator);
        }

        public IEnumerable<string> ExpandViewLocations(
            ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            var viewLocationFormats = new[]
            {
                "~/Modules/{1}/Views/{0}.cshtml",
                "~/Modules/Shared/Views/{0}.cshtml",
            };
            return viewLocationFormats;
        }
    }
}
