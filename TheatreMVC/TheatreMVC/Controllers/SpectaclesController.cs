using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheatreMVC;

namespace TheatreMVC.Controllers
{
    public class SpectaclesController : Controller
    {
        private TheatreEntities db = new TheatreEntities();

        // GET: Spectacles
        public async Task<ActionResult> Index()
        {
            return View(await db.Spectacles.ToListAsync());
        }

        // GET: Spectacles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spectacle spectacle = await db.Spectacles.FindAsync(id);
            if (spectacle == null)
            {
                return HttpNotFound();
            }
            return View(spectacle);
        }

        // GET: Spectacles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spectacles/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Spectacle_id,Spectacle_name,Exposition_sp,Date_sp,Actor1,Actor2,Actor3,Actor4,Actor5,Actor6,Actor7,Actor8,Actor9,Actor10")] Spectacle spectacle)
        {
            if (ModelState.IsValid)
            {
                db.Spectacles.Add(spectacle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(spectacle);
        }

        // GET: Spectacles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spectacle spectacle = await db.Spectacles.FindAsync(id);
            if (spectacle == null)
            {
                return HttpNotFound();
            }
            return View(spectacle);
        }

        // POST: Spectacles/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Spectacle_id,Spectacle_name,Exposition_sp,Date_sp,Actor1,Actor2,Actor3,Actor4,Actor5,Actor6,Actor7,Actor8,Actor9,Actor10")] Spectacle spectacle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spectacle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(spectacle);
        }

        // GET: Spectacles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spectacle spectacle = await db.Spectacles.FindAsync(id);
            if (spectacle == null)
            {
                return HttpNotFound();
            }
            return View(spectacle);
        }

        // POST: Spectacles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Spectacle spectacle = await db.Spectacles.FindAsync(id);
            db.Spectacles.Remove(spectacle);
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
