using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class HomeController : Controller
    {
        TiendaEntities te = new TiendaEntities();
        // GET: Home
        public ActionResult Index()
        {
            var result = (from cat in te.Categorias
                          join prod in te.Productos on cat.Id equals prod.Categoria
                          select cat).Distinct();
            // return View(te.Categorias);
            return View(result);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Servicio al Cliente";

            return View();
        }
    }
}