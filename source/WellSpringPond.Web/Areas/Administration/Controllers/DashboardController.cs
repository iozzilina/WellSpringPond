namespace WellSpringPond.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.UI;
    using WellSpringPond.Models.ViewModels.Users;
    using WellSpringPond.Web.Attributes;
    using WellSpringPond.Models.ViewModels.WaterSources;
    using WellSpringPond.Services;

    //[AdminAuthorize(Roles = "Administrator")] //breaks the routing
    //[RouteArea("administration")]
    //[RoutePrefix("dashboard")]
    public class DashboardController : Controller
    {
        private WaterSourceService waterService;
        private UserService userService;

        public DashboardController()
        {
            this.waterService = new WaterSourceService();
            this.userService = new UserService();
        }

        // GET: Administration/Dashboard
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: Administration/Dashboard/WaterSources/All
        public ActionResult WaterSources()
        {
            IEnumerable<WaterSourcesBasicDataVm> waters = this.waterService.GetWsBasicData();
            return this.View(waters);
        }


        // GET: Administration/Dashboard/WaterSources/1
        [HttpGet]
        public ActionResult WaterSourceDetail(int id)
        {
            WaterSourcesAdminDataVm vm = this.waterService.GetWsAdminData(id);

            if (vm == null)
            {
                return this.HttpNotFound();
            }

            return this.View(vm);
        }

        // GET: Administration/Dashboard/Users/All
        [HttpGet]
        public ActionResult UserList()
        {
            IEnumerable<AdminUserBasicDataVm> vms = this.userService.GetAllUserForAdminList();
            
            return this.View(vms);
        }
        
    }
}
