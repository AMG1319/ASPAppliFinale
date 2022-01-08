using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDAutoASP.Models;

namespace ASPAppliFinale.Controllers
{
    public class PropriosController : Controller
    {
        private BDContext db = new BDContext();

        // GET: Proprios
        [Authorize]
        public ActionResult Index()
        {
            ViewData["Mail"] = User.Identity.Name;
            return View(db.Proprios.ToList());
        }


        // GET: Proprios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proprios/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProprio,PNom,PPrenom,PNumTel,PMail,PMdp")] Proprio proprio)
        {
            if (ModelState.IsValid)
            {
                db.Proprios.Add(proprio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proprio);
        }

        // GET: Proprios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprio proprio = db.Proprios.Find(id);
            if (proprio == null)
            {
                return HttpNotFound();
            }
            return View(proprio);
        }

        // POST: Proprios/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProprio,PNom,PPrenom,PNumTel,PMail,PMdp")] Proprio proprio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proprio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proprio);
        }

        // GET: Proprios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprio proprio = db.Proprios.Find(id);
            if (proprio == null)
            {
                return HttpNotFound();
            }
            return View(proprio);
        }

        // POST: Proprios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proprio proprio = db.Proprios.Find(id);
            db.Proprios.Remove(proprio);
            db.SaveChanges();
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
