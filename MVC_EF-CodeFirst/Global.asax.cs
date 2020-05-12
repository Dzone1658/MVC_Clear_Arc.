using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_EF_CodeFirst
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MVC.DependencyContainer.RegisterDependencies( );
            AutoMapper.Mapper.Initialize( config => config.AddProfile<MVC.AutoMapperDependencies>( ) );
            AreaRegistration.RegisterAllAreas( );
            FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes( RouteTable.Routes );
            BundleConfig.RegisterBundles( BundleTable.Bundles );
        }
    }
}
