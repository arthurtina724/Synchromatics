using System.Web.Http;
using Synchromatics.Host.DependencyResolution;

namespace Synchromatics.Host
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            var container = IoC.Initialize();
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapHttpDependencyResolver(container);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
