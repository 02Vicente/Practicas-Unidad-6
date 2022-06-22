﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Practica_VI_IV_Model.Models;

namespace Practica_VI_IV.Controllers
{
    public class HomeController : Controller
    {
        SessionData session = new SessionData();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Usuarios(UserLogin datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.Login() == true)
                {
                    session.setSession("userName", datos.Username);
                    ViewBag.User = session.getSession("userName");
                    return RedirectToAction("Users", "User");
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [AllowAnonymous]
        public ActionResult SingIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SingIn(Signin datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.Sign_in() == false)
                {
                    ViewBag.Message = "El Usuario o Email Ya esta Registrado";
                    return View("SingIn", datos);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("SingIn");
            }
        }
    }
}