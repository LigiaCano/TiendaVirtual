using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtual.Models
{
    public class CarritoCompra: List<Producto>
    {
        public decimal TotalCompra { get; set; }

    }
}