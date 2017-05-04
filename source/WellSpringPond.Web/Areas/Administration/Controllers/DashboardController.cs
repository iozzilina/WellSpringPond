namespace WellSpringPond.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using WellSpringPond.Web.Attributes;

    //[AdminAuthorize(Roles = "Administrator")] //breaks the routing
    //[RouteArea("Administration/Dashboard")]
    public class DashboardController : Controller
    {
        // GET: Administration/Dashboard
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: Administration/Dashboard/WaterSources/All
        public ActionResult WaterSources()
        {
            return this.View();
        }

        // GET: Administration/Dashboard/Users/All
        public ActionResult Users()
        {
            return this.View();
        }
        
    }
}
