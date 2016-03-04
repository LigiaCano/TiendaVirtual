using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TiendaVirtual.Models;
using TiendaVirtual.Models.Binder;

namespace TiendaVirtual
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Login), new UsuarioBinderModel());
            ModelBinders.Binders.Add(typeof(CarritoCompra), new CarritoCompraModelBinder());
        }
    }
}
