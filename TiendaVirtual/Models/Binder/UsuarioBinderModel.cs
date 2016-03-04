using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtual.Models.Binder
{
    public class UsuarioBinderModel : IModelBinder
    {
        public string SessionKey = "usuario_session";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Login usuario = (controllerContext.HttpContext.Session != null) ? (controllerContext.HttpContext.Session[SessionKey] as Login) : null;
            if (usuario == null)
            {
                usuario = new Login();
                controllerContext.HttpContext.Session[SessionKey] = usuario;
            }
            return usuario;
        }
    }
}