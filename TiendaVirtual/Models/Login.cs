using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtual.Models
{
    public class Login: Usuario 
    {
        public bool Validate = false;

        public override string ToString()
        {
            return "Hola " + Nombre + " " + Apellido + "!";
        }
    }
}