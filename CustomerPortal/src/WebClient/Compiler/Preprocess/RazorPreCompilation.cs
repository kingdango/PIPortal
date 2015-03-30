using System;
using Microsoft.AspNet.Mvc;

namespace CustomerPortal.Compiler.Preprocess
{
    public class RazorPreCompilation : RazorPreCompileModule
    {
        public RazorPreCompilation(IServiceProvider provider) : base(provider)
        {
        }
        
    }
}
