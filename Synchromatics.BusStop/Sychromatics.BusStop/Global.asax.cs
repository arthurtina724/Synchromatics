using System.Web.Http;
using Sychromatics.BusStop.DependencyResolution;

namespace Sychromatics.BusStop
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = IoC.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
