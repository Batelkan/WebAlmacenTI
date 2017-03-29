using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.Areas.AreaComputadoras.Models
{
    public class ComputadoraViewModel
    {
        public IEnumerable<Computadoras> ListaComputadoras { get; set; }
        public PaginacionInfo PaginaInfo { get; set; }
        public int itemsPorPagina { get; set; }
        public string CampoBusqueda { get; set; }
        public string terminoBusqueda { get; set; }
        public string OrdenFecha { get; set; }
    }
}