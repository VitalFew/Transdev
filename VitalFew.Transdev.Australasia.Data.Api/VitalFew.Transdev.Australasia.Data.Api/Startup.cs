using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(VitalFew.Transdev.Australasia.Data.Api.Startup))]

namespace VitalFew.Transdev.Australasia.Data.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
