using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssessmentsPOC.Startup))]
namespace AssessmentsPOC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
