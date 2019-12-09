using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Practica_VI_II_Model.Models;

namespace Practica_VI_II.Controllers
{
    public class HomeController : Controller
    {
        EmpleadosDB empDB = new EmpleadosDB();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(empDB.ListAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Empleado emp)
        {
            return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            var Empleado = empDB.ListAll().Find(x => x.EmpleadoID.Equals(ID));
            return Json(Empleado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Empleado emp)
        {
            return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int ID)
        {
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
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
    }
}