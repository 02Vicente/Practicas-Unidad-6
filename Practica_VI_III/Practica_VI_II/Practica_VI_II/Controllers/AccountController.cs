using Practica_VI_II_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Practica_VI_II.Controllers
{
    public class AccountController : Controller
    {
        private UsuarioDB u_db = new UsuarioDB();
        // GET: Account
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Login(string Username, string Password)
        {
            object response;

            if (string.IsNullOrEmpty(Username.Trim()) || string.IsNullOrEmpty(Password.Trim()))
            {
                response = new { result = false};
            }
            else
            {
                var data = u_db.Login(Username, Password);
                if (data != null)
                {
                    Session["Nombre"]    = data.Nombre;
                    Session["Apellido"]  = data.Apellido;
                    Session["Correo"]    = data.Correo;
                    Session["UsuarioId"] = data.UsuarioId;

                    FormsAuthentication.SetAuthCookie(data.Username, false);
                    response = new { result = true, url = Url.Action("Index", "Home") };
                }
                else
                {
                    response = new { result = false};
                }
            }

            return Json(new { response }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }
    }
}