
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WellSpringPond.Web
{
    using System.Collections.Generic;
    using AutoMapper;
    using WellSpringPond.Models.EntityModels;
    using WellSpringPond.Models.ViewModels.WaterSources;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            this.ConfigureMappings();


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<WaterSource, WaterSourcesBasicDataVm>();
                //expression.CreateMap<IEnumerable<WaterSource>, IEnumerable<WaterSourcesBasicDataVm>>();
                expression.CreateMap<WaterSource, WaterSourcesAdminDataVm>();
                expression.CreateMap<WaterSource, WaterSourcesDetailDataVm>();
            });
        }
    }
}
