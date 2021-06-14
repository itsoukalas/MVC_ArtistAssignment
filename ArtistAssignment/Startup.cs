using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtistAssignment.Startup))]
namespace ArtistAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
