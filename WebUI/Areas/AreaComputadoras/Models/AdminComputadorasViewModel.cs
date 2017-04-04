using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Modelo;
using System.Web.Mvc;

namespace WebUI.Areas.AreaComputadoras.Models
{
    public class AdminComputadorasViewModel
    {
        public Computadoras computadoras { get; set; }
        public IEnumerable<SelectListItem> categoria { get; set; }
    }
}