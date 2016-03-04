using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class ProductoController : Controller
    {
        TiendaEntities te = new TiendaEntities();

        // GET: Producto
        [ChildActionOnly]
        public ActionResult Index(Categoria c)
        {
            var result =(from producto in te.Productos
                         where producto .Categoria == c.Id
                         select producto).Distinct();
            return PartialView("_Producto",result);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = te.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }
    }
}