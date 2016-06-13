using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace CoreWeb1.Infrastructure
{
    /// <summary>
    /// Support for the Modules/Domain/Views
    /// http://hossambarakat.net/2016/02/16/asp-net-core-mvc-feature-folders/
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
