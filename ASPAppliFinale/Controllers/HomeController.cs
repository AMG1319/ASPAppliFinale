using BDAutoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPAppliFinale.Controllers
{
    public class HomeController : Controller
    {
        private BDContext db = new BDContext();
        public ActionResult Index()
        {
            ViewBag.IDModel = new SelectList(db.Modeles, "IDModel", "MNom");
            ViewBag.IDProprio = new SelectList(db.Proprios, "IDProprio", "PNom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "IDAnnonce,IDProprio,IDModel,AAnnee,AKilometrage,ACouleur,APrix,AStatut")] Annonce annonce)
        {
            return RedirectToAction("AnnoncesEnligne", "Home",  annonce);
        }

        public ActionResult AnnoncesEnligne([Bind(Include = "IDAnnonce,IDProprio,IDModel,AAnnee,AKilometrage,ACouleur,APrix,AStatut")] Annonce annonce)
        {
                    var annonces = db.Annonces.Where(a=> a.IDModel == annonce.IDModel);

                    return View(annonces.ToList());
        }
    }
}