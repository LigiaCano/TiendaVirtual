using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class PedidoController : Controller
    {
        TiendaEntities te = new TiendaEntities();

        public ActionResult Save(Login usuario_session,CarritoCompra carrito_session)
        {
          if (carrito_session.Count == 0)
            {
                TempData["msg"] = "<script>alert('No hay productos en el carrito');</script>";
                return RedirectToAction("Show", "Carrito");
            }
     
          if (usuario_session.Validate)
            {
                Pedido pedido = new Pedido();
                Usuario usuasio = new Usuario();
                pedido.Fecha = DateTime.Now;
                pedido.Usuario = usuario_session.Id;
                pedido.Total = carrito_session.TotalCompra;
                pedido.Estado = 0;
                te.Pedidos.Add(pedido);
                te.SaveChanges();
                int id = pedido.Id;
                foreach (var item in carrito_session)
                {
                    Producto producto = te.Productos.Find(item.Id);
                    producto.Stock = item.Stock;
                    te.Entry(producto).State = EntityState.Modified;
                    PedidoDetalle detalle = new PedidoDetalle();
                    detalle.Pedido = id;
                    detalle.Producto = item.Id;
                    detalle.Cantidad = item.Cantidad;
                    detalle.Total = item.Total;
                    te.PedidoDetalles.Add(detalle);
                }
                carrito_session.Clear();
                te.SaveChanges();
                return RedirectToAction("Details", new { id = id});
            }
            return RedirectToAction("Login", "Usuario");
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int? id, Login usuario_session)
        {
            if (usuario_session.Validate)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Pedido pedido = te.Pedidos.Where(p => p.Id == id && p.Usuario == usuario_session.Id).First();
                pedido.EstadoNombre = te.Estados.Find(pedido.Estado).Nombre;
                if (pedido == null)
                {
                    return HttpNotFound();
                }
                return View(pedido);
            }
            else
                return RedirectToAction("Login", "Usuario");
        }

        // GET: Producto
        [ChildActionOnly]
        public ActionResult DetailsPedido(Pedido p)
        {
            var result = (from pedidoDetalle in te.PedidoDetalles
                          where pedidoDetalle.Pedido == p.Id
                          select pedidoDetalle);
            foreach (var item in result)
            {
                item.ProductoNombre = te.Productos.Find(item.Producto).Nombre;
                item.Precio = te.Productos.Find(item.Producto).Precio;
            }
                         
            return PartialView("_PedidoDetalle", result);
        }

    }
}