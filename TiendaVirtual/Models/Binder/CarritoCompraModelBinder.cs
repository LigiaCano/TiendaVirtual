using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtual.Models.Binder
{
    public class CarritoCompraModelBinder : IModelBinder
    {
        public string SessionKey = "carrito_session";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CarritoCompra carritocompra = (controllerContext.HttpContext.Session != null) ? (controllerContext.HttpContext.Session[SessionKey] as CarritoCompra) : null;
            if (carritocompra == null)
            {
                carritocompra = new CarritoCompra();
                controllerContext.HttpContext.Session[SessionKey] = carritocompra;
            }
            return carritocompra;
        }
    }
}