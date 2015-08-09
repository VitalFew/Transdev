using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(VitalFew.Transdev.Australasia.DataPublisher.Startup))]

namespace VitalFew.Transdev.Australasia.DataPublisher
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
