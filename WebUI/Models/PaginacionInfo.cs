using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PaginacionInfo
    {
        public int ItemsTotales { get; set; }
        public int ItemPorPagina { get; set; }
        public int PaginaActual { get; set; }
        public int TotalPaginas
        {
            get { return (int)Math.Ceiling( (decimal)ItemsTotales/ ItemPorPagina); }
            set { }
        }

    }


}