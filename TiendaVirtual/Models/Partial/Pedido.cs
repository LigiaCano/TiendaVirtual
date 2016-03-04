using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtual.Models
{
    public partial class Pedido
    {
        [Display(Name = "Estado")]
        public String EstadoNombre { get; set; }
    }
}