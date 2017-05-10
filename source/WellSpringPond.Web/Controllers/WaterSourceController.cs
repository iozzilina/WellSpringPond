namespace WellSpringPond.Web.Controllers
{
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using WellSpringPond.Models.BindingModels;
    using WellSpringPond.Models.EntityModels;
    using WellSpringPond.Models.ViewModels.Comments;
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
            WaterSourcesDetailDataVm vm = this.waterService.GetWsDetailData(id);

            if (vm == null)
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View(vm);
        }


        // GET: WaterSource/Create
        [Route("quick-add")]
        public ActionResult QuickAdd()
        {
            WaterSourceQuickAddVm vm = new WaterSourceQuickAddVm();
            vm.WaterTypesDropDown = this.waterService.GetDropDownListForWaterTypes();

            return this.View(vm);
        }
        
        // POST: WaterSource/Create
        [HttpPost]
        [Route("quick-add")]
        public ActionResult QuickAdd([Bind(Include = "Name,Type,Latitude,Longitude,IsDrinkable")] WaterSourceQuickAddBm bind)
        {
            if (this.ModelState.IsValid)
            {
                bind.author = this.User.Identity.GetUserName();
                this.waterService.QuickAddWaterSource(bind);

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

         //GET: WaterSource/CommentAdd{id}
        [Route("commentAdd/{id}")]
        public ActionResult CommentAdd(int id)
        {
            CommentAddVm vm = new CommentAddVm {WsId = id};

            return this.View(vm);
        }

        // POST: Test/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("commentAdd/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CommentAdd([Bind(Include = "Id,WsId,CommentText,DatePosted")] CommentAddBm bind)
        {
            if (ModelState.IsValid)
            {
                bind.Author= this.User.Identity.GetUserName();
                this.waterService.CommentAdd(bind);
                return this.RedirectToAction("Details","WaterSource",new {id = bind.WsID});
            }

            return RedirectToAction("Details", "WaterSource", new { id = bind.WsID });
        }


        // GET: waters/1/commentdelete/5
        [HttpGet]
        [Route("{wsId}/commentDelete/{cId}")]
        public ActionResult CommentDelete(int wsId,int? cId)
        {
            if (cId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.waterService.GetComment(cId);

            if (comment == null)
            {
                return this.HttpNotFound();
            }

            CommentAddVm vm = new CommentAddVm
            {
                WsId = wsId,
                Id = (int)cId,
                CommentText = comment.CommentText
            };

            return this.View(vm);
       }

        //POST: waters/1/commentdelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{wsId}/commentDelete/{cId}")]
        public ActionResult CommentDeleteConfirmed(int wsId, int cId)
        {
            this.waterService.CommentDelete(cId);

            return RedirectToAction("Details", "WaterSource", new { id = wsId });
        }
        

        // GET: WaterSource/CommentEdit{id}
        [Route("commentEdit/{commentId}")]
        public ActionResult CommentEdit(int commentId)
        {
            CommentVm vm = new CommentVm();
            return this.RedirectToAction("Index", "Home");
        }


        //// GET: WaterSource/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: WaterSource/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
       
    }
}
