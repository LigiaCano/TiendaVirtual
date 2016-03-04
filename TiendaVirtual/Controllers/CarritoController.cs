using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class CarritoController : Controller
    {
        TiendaEntities te = new TiendaEntities();
        // GET: Carrito
        public ActionResult AddProducto(CarritoCompra carrito_session, int id)
        {
            Producto pro = carrito_session.Find(p => p.Id == id);

            if (pro == null) {
                Producto nuevo = te.Productos.Find(id);
                carrito_session.Add(nuevo);
                pro= nuevo;
            }
            if (pro.Stock> 0)
            {
                pro.Cantidad++;
                pro.Stock--;
                pro.Total = pro.Precio * pro.Cantidad;
                carrito_session.TotalCompra = carrito_session.TotalCompra + pro.Precio;
            }
            else
                TempData["msg"] = "<script>alert('El carrito tiene todo el stock');</script>";
            return RedirectToAction("Index", "Home");
        }

        
        public ActionResult Count(CarritoCompra carrito_session)
        {
            return PartialView("_PartialCarritoInfo", carrito_session);
        }

        public ActionResult Show(CarritoCompra carrito_session)
        {
            return View(carrito_session);
        }

        public ActionResult Delete(CarritoCompra carrito_session, int id)
        {
            Producto pro = carrito_session.Find(p => p.Id == id);
            carrito_session.TotalCompra = carrito_session.TotalCompra - pro.Total;
            carrito_session.Remove(pro);
            return RedirectToAction("Show");
        }
    }
}