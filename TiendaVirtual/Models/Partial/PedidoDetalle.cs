using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtual.Models
{
    public partial class PedidoDetalle
    {
        [Display(Name = "Producto")]
        public String ProductoNombre { get; set; }

        public decimal Precio { get; set; }
    }
}