using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVC.Controllers;

namespace MVC_EF_CodeFirst
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AutoMapper.Mapper.Initialize( config => config.AddProfile<AutoMapperDependecies>( ) );
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //ModelBinders.Binders.DefaultBinder = new CategoryController( );
        }
    }
}
