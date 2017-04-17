using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Modelo;
using Dominio.Concreto;
using Dominio.Abstracto;
using WebUI.Areas.AreaComputadoras.Models;

namespace WebUI.Areas.AreaComputadoras.Controllers
{
    public class AdminComputadorasController : Controller
    {
        // GET: AreaComputadoras/AdminComputadoras
       

        private IComputadorasRepositorio repositorio;

        public AdminComputadorasController ( IComputadorasRepositorio repo )
        {
            repositorio = repo;
        }


        public ActionResult Crear( )
        {
            ViewBag.IDsuministro = "";
            ViewBag.Operacion = "Nuevo Suministro";
            return View("Editar", new Dominio.Modelo.Computadoras());
        }


        public ViewResult Editar( int id )
        {
            AdminComputadorasViewModel modelo = new AdminComputadorasViewModel();
            modelo.computadoras = repositorio.Computo.FirstOrDefault(c => c.ID == id);
            modelo.categoria = repositorio.categoria.Select(c => new SelectListItem() { Text = c.Tipo1.ToString() });
            ViewBag.IDsuministro = id;
            ViewBag.Operacion = "Editar";
            return View("Editar", modelo);
        }
    }
}