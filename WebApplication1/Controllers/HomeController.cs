using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EntityProduct datos = new EntityProduct();

            var productos = datos.ObtenerProductos();
            return View(productos);
        }

        [HttpPost]
        public ActionResult GuardarProducto(ProductModel modelo)
        {
            EntityProduct datos = new EntityProduct();

            datos.GuardarProducto(modelo);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult EditarProducto(int edit, string nombre)
        {
            EntityProduct datos = new EntityProduct();

            var editado = datos.EditarProducto(edit,nombre);

            return Json(new { success = editado });
        }

        [HttpPost]
        public JsonResult EliminarProducto(int deletes)
        {
            EntityProduct datos = new EntityProduct();

            var editado = datos.EliminarProducto(deletes);

            return Json(new { success = editado });
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