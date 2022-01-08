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
            return View();
        }

    }
}