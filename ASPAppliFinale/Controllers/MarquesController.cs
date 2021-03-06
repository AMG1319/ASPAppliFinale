using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPAppliFinale.Models;

namespace ASPAppliFinale.Controllers
{
    public class MarquesController : Controller
    {
        private BDContext db = new BDContext();

        // GET: Marques
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Marques.ToList());
        }
        // GET: Marques/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marques/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDMarque,MNom")] Marque marque)
        {
            if (ModelState.IsValid)
            {
                db.Marques.Add(marque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marque);
        }

        // GET: Marques/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marque marque = db.Marques.Find(id);
            if (marque == null)
            {
                return HttpNotFound();
            }
            return View(marque);
        }

        // POST: Marques/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDMarque,MNom")] Marque marque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marque);
        }

        // GET: Marques/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marque marque = db.Marques.Find(id);
            if (marque == null)
            {
                return HttpNotFound();
            }
            return View(marque);
        }

        // POST: Marques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Marque marque = db.Marques.Find(id);
            db.Marques.Remove(marque);
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
