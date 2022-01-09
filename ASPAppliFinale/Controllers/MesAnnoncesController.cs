using ASPAppliFinale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}