﻿using ASPAppliFinale.ViewModel;
using BDAutoASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASPAppliFinale.Controllers
{
    public class LoginsController : Controller
    {
        private BDContext db = new BDContext();
        private int ID;
        // GET: Logins
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(VMProprio user, string ReturnUrl)
        {
            if(IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(user);
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
        private bool IsValid(VMProprio user)
        {
            var userDetails = db.Proprios.Where(x => x.PMail == user.Email && x.PMdp == user.Mdp).FirstOrDefault();

            if (userDetails == null)
                return false;
            else
            {
                ID = userDetails.IDProprio;
                return true;
            }
                
        }
    }
}