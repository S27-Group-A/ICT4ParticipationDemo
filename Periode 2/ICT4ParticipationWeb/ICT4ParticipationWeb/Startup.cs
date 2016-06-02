using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICT4ParticipationWeb.Startup))]
namespace ICT4ParticipationWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
