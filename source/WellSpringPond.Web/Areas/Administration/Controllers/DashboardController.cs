namespace WellSpringPond.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using WellSpringPond.Web.Attributes;
    using WellSpringPond.Models.ViewModels.WaterSources;
    using WellSpringPond.Services;

    //[AdminAuthorize(Roles = "Administrator")] //breaks the routing
    //[RouteArea("Administration/Dashboard")]
    public class DashboardController : Controller
    {
        private WaterSourceService service;

        public DashboardController()
        {
            this.service = new WaterSourceService();
        }

        // GET: Administration/Dashboard
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: Administration/Dashboard/WaterSources/All
        public ActionResult WaterSources()
        {
            IEnumerable<WaterSourcesBasicDataVm> waters = this.service.GetWsBasicData();
            return this.View(waters);
        }


        // GET: Administration/Dashboard/WaterSources/1
        [HttpGet, Route("watersources/{id}")]
        public ActionResult WaterSourceDetail(int id)
        {
            WaterSourcesAdminDataVm vm = this.service.GetWsAdminData(id);

            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        // GET: Administration/Dashboard/Users/All
        public ActionResult Users()
        {

            return this.View();
        }
        
    }
}
