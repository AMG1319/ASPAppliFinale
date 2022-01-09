using ASPAppliFinale.ViewModel;
using ASPAppliFinale.Models;
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
            ViewBag.IDMarque = new SelectList(db.Marques, "IDMarque", "MNom");
            ViewBag.IDModel = new SelectList(db.Modeles, "IDModel", "MNom");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "IDMarque,IDModel,AAnnee,AKilometrage,ACouleur,APrix")] VMParamRecherche critere)
        {
            return RedirectToAction("AnnoncesEnligne", "Home",  critere);
        }

        public ActionResult AnnoncesEnligne([Bind(Include = "IDMarque,IDModel,AAnnee,AKilometrage,ACouleur,APrix")] VMParamRecherche critere)
        {
            List<VMAnnonce> a = new List<VMAnnonce>();
            List<Annonce> annonce = db.Annonces.Where(x => x.AStatut == "Disponible").ToList();
            foreach (Annonce An in annonce)
            {
                Proprio pr = db.Proprios.Where(x => x.IDProprio == An.IDProprio).FirstOrDefault();
                Modele md = db.Modeles.Where(x => x.IDModel == An.IDModel).FirstOrDefault();
                Marque mr = db.Marques.Where(x => x.IDMarque == md.IDMarque).FirstOrDefault();
                VMAnnonce View = new VMAnnonce()
                {
                    VMProprio = pr,
                    VMMarque = mr,
                    VMModele = md,
                    VMAnnonc = An
                };
                a.Add(View);
            }
            if (critere.IDMarque==0&&critere.IDModel==0&&critere.AAnnee==null&&critere.APrix==0&&critere.AKilometrage==null&&critere.ACouleur==null)
            {
                
                return View(a);
            }
            else
            {
                int annee = Convert.ToInt32(critere.AAnnee);
                int km = Convert.ToInt32(critere.AKilometrage);
                List<VMAnnonce> VM2 = new List<VMAnnonce>();

                var rep = from an in a
                where (an.VMMarque.IDMarque == critere.IDMarque || critere.IDMarque==0)
                &&(an.VMModele.IDModel==critere.IDModel || critere.IDModel==0)
                &&(Convert.ToInt32(an.VMAnnonc.AAnnee)>annee||annee==0)
                &&(Convert.ToInt32(an.VMAnnonc.AKilometrage)<km||km==0)
                &&(an.VMAnnonc.APrix<critere.APrix||critere.APrix==0)
                &&(an.VMAnnonc.ACouleur==critere.ACouleur||critere.ACouleur==null)
                select new VMAnnonce {
                    VMProprio = an.VMProprio,
                    VMMarque = an.VMMarque,
                    VMModele = an.VMModele,
                    VMAnnonc = an.VMAnnonc
                };
                foreach (var x in rep)
                    VM2.Add(x);
                return View(VM2);
            }

                //return RedirectToAction("Index", "Home");
        }
    }
}