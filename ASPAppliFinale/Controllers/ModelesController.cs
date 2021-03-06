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
    public class ModelesController : Controller
    {
        private BDContext db = new BDContext();

        // GET: Modeles
        [Authorize]
        public ActionResult Index()
        {
            var modeles = db.Modeles.Include(m => m.Marque);
            return View(modeles.ToList());
        }

        // GET: Modeles/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDMarque = new SelectList(db.Marques, "IDMarque", "MNom");
            return View();
        }

        // POST: Modeles/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDModel,IDMarque,MNom")] Modele modele)
        {
            if (ModelState.IsValid)
            {
                db.Modeles.Add(modele);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDMarque = new SelectList(db.Marques, "IDMarque", "MNom", modele.IDMarque);
            return View(modele);
        }

        // GET: Modeles/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele modele = db.Modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDMarque = new SelectList(db.Marques, "IDMarque", "MNom", modele.IDMarque);
            return View(modele);
        }

        // POST: Modeles/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDModel,IDMarque,MNom")] Modele modele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDMarque = new SelectList(db.Marques, "IDMarque", "MNom", modele.IDMarque);
            return View(modele);
        }

        // GET: Modeles/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modele modele = db.Modeles.Find(id);
            if (modele == null)
            {
                return HttpNotFound();
            }
            return View(modele);
        }

        // POST: Modeles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Modele modele = db.Modeles.Find(id);
            db.Modeles.Remove(modele);
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
