using Practica_VI_II_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica_VI_II.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private UsuarioDB userdb = new UsuarioDB();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(userdb.ListAll());
        }

        public ActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Usuario usuario)
        {
            if (userdb.Add(usuario) > 0)
            {
              return RedirectToAction("Index", "Usuario");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int Id)
        {
            return View(userdb.Buscar(Id));
        }

        [HttpPost]
        public ActionResult Update(Usuario usuario)
        {
            if (userdb.Update(usuario) > 0)
            {
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            if (userdb.Delete(Id) > 0)
            {
                return RedirectToAction("Index", "Usuario");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Details(int Id)
        {
            return View(userdb.Buscar(Id));
        }
    }
}