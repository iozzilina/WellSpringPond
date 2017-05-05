using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WellSpringPond.Data;
using WellSpringPond.Models.EntityModels;

namespace WellSpringPond.Web.Areas.Test.Controllers
{
    public class WaterSourcesController : Controller
    {
        private WellSpringPondContext db = new WellSpringPondContext();

        // GET: Test/WaterSources
        public async Task<ActionResult> Index()
        {
            return View(await db.WaterSources.ToListAsync());
        }

        // GET: Test/WaterSources/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterSource waterSource = await db.WaterSources.FindAsync(id);
            if (waterSource == null)
            {
                return HttpNotFound();
            }
            return View(waterSource);
        }

        // GET: Test/WaterSources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/WaterSources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PlaceId,Name,Temperature,MineralContent,Description,ImageUrl")] WaterSource waterSource)
        {
            if (ModelState.IsValid)
            {
                db.WaterSources.Add(waterSource);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(waterSource);
        }

        // GET: Test/WaterSources/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterSource waterSource = await db.WaterSources.FindAsync(id);
            if (waterSource == null)
            {
                return HttpNotFound();
            }
            return View(waterSource);
        }

        // POST: Test/WaterSources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PlaceId,Name,Temperature,MineralContent,Description,ImageUrl")] WaterSource waterSource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waterSource).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(waterSource);
        }

        // GET: Test/WaterSources/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WaterSource waterSource = await db.WaterSources.FindAsync(id);
            if (waterSource == null)
            {
                return HttpNotFound();
            }
            return View(waterSource);
        }

        // POST: Test/WaterSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WaterSource waterSource = await db.WaterSources.FindAsync(id);
            db.WaterSources.Remove(waterSource);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
