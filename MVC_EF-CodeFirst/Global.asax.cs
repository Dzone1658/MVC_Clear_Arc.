using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyContainer.RegisterDependencies( );
            AutoMapper.Mapper.Initialize( config => config.AddProfile<AutoMapperDependencies>( ) );
            AreaRegistration.RegisterAllAreas( );
            FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes( RouteTable.Routes );
            BundleConfig.RegisterBundles( BundleTable.Bundles );
        }
    }
}
