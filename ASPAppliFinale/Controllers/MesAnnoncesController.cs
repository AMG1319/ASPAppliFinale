using ASPAppliFinale.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASPAppliFinale.Controllers
{
    public class MesAnnoncesController : Controller
    {
        private BDContext db = new BDContext();
        // GET: MesAnnonces
        [Authorize]
        public ActionResult Index()
        {
            Proprio pr = db.Proprios.Where(a => a.PMail == System.Web.HttpContext.Current.User.Identity.Name ).FirstOrDefault();
            var annonces = db.Annonces.Where(a=>a.IDProprio == pr.IDProprio);
            return View(annonces.ToList());
        }
        // GET: Annonces/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.IDModel = new SelectList(db.Modeles, "IDModel", "MNom");
            ViewBag.IDProprio = new SelectList(db.Proprios, "IDProprio", "PNom");
            return View();
        }

        // POST: Annonces/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDAnnonce,IDProprio,IDModel,AAnnee,AKilometrage,ACouleur,APrix,AStatut")] Annonce annonce)
        {
            Proprio pr = db.Proprios.Where(a => a.PMail == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();
            if (ModelState.IsValid)
            {
                annonce.IDProprio = pr.IDProprio;
                db.Annonces.Add(annonce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDModel = new SelectList(db.Modeles, "IDModel", "MNom", annonce.IDModel);
            ViewBag.IDProprio = new SelectList(db.Proprios, "IDProprio", "PNom", annonce.IDProprio);
            return View(annonce);
        }

        // GET: Annonces/Vendu/5
        [Authorize]
        public ActionResult Vendu(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Annonce a = new Annonce();
                a = db.Annonces.Find(id);
                a.AStatut = "Vendu";
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        // GET: Annonces/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.Annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDModel = new SelectList(db.Modeles, "IDModel", "MNom", annonce.IDModel);
            ViewBag.IDProprio = new SelectList(db.Proprios, "IDProprio", "PNom", annonce.IDProprio);
            return View(annonce);
        }

        // POST: Annonces/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDAnnonce,IDProprio,IDModel,AAnnee,AKilometrage,ACouleur,APrix,AStatut")] Annonce annonce)
        {
            Proprio pr = db.Proprios.Where(a => a.PMail == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();
            if (ModelState.IsValid)
            {
                annonce.IDProprio = pr.IDProprio;
                db.Entry(annonce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDModel = new SelectList(db.Modeles, "IDModel", "MNom", annonce.IDModel);
            ViewBag.IDProprio = new SelectList(db.Proprios, "IDProprio", "PNom", annonce.IDProprio);
            return View(annonce);
        }

        // GET: Annonces/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.Annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            return View(annonce);
        }

        // POST: Annonces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Annonce annonce = db.Annonces.Find(id);
            db.Annonces.Remove(annonce);
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