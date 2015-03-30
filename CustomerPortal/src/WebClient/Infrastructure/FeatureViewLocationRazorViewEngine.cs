using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc.Razor;
using Microsoft.AspNet.Mvc.Razor.OptionDescriptors;

namespace CustomerPortal.Infrastructure
{
    public class FeatureViewLocationRazorViewEngine : RazorViewEngine
    {
        public override IEnumerable<string> ViewLocationFormats
        {
            get
            {
                var existing = base.ViewLocationFormats.ToList();
                existing.Add("App/{1}/{0}.cshtml");
                return existing;
            }
        }

        public FeatureViewLocationRazorViewEngine(IRazorPageFactory pageFactory, IRazorViewFactory viewFactory, IViewLocationExpanderProvider viewLocationExpanderProvider, IViewLocationCache viewLocationCache)
            : base(pageFactory, viewFactory, viewLocationExpanderProvider, viewLocationCache)
        {

        }
    }
}