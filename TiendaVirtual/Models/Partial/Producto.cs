using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtual.Models
{
    public partial class Producto
    {
        public int Cantidad { get; set; }

        public decimal Total { get; set; }
    }
}