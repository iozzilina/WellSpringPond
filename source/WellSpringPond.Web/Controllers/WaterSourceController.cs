namespace WellSpringPond.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using WellSpringPond.Models.EntityModels;
    using WellSpringPond.Models.ViewModels.WaterSources;
    using WellSpringPond.Services;

    [RoutePrefix("water")]
    [Authorize]
    public class WaterSourceController : Controller
    {

        private WaterSourceService waterService;
        private UserService userService;

        public WaterSourceController()
        {
            this.waterService = new WaterSourceService();
            this.userService = new UserService();
        }

        // GET: WaterSource
        [AllowAnonymous]
        [ChildActionOnly]
        [Route("short-list")]
        public ActionResult ShortList()
        {
            Geolocation searchLocation = new Geolocation()
            {
                Latitude = 21.4444M,
                Longtitude = 224.22M,
                Altitude = 44
            };

            //IEnumerable<WaterSourcesBasicDataVm> vms = this.waterService.GetWsBasicData();
            IEnumerable<WaterSourcesBasicDataVm> vms = this.waterService.GetClosest10(searchLocation);

            return this.PartialView(vms);
        }

        [AllowAnonymous]
        [ChildActionOnly]
        [Route("recent")]
        public ActionResult Recent()
        {
            IEnumerable<WaterSourcesBasicDataVm> vms = this.waterService.GetRecent5();
            return this.PartialView(vms);
        }


        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: WaterSource/Create
        [Route("quick-add")]
        public ActionResult QuickAdd()
        {
            return View();
        }

        // POST: WaterSource/Create
        [HttpPost]
        [Route("quick-add")]
        public ActionResult QuickAdd(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WaterSource/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WaterSource/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WaterSource/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WaterSource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
