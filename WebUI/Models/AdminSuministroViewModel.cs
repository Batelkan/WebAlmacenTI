using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Modelo;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class AdminSuministroViewModel
    {

        public Articulos suministro { get; set; }
        public IEnumerable<SelectListItem> categoria { get; set; }
    }
}