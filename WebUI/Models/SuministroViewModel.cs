using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Modelo;

namespace WebUI.Models
{
    public class SuministroViewModel
    {
       public IEnumerable<Articulos> ListaArticulos { get; set; }
       public PaginacionInfo PaginaInfo { get; set; }
         public int itemsPorPagina {get;set;}
    }
}