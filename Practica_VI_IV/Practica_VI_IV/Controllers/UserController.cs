using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica_VI_IV_Model.Models;

namespace Practica_VI_IV.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        SessionData session = new SessionData();
        // GET: User
        public ActionResult Users()
        {
            ViewBag.User = session.getSession("userName");

            if (ViewBag.User == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Close()
        {
            session.destroySession();
            return RedirectToAction("Users", "User");
        }
    }
}