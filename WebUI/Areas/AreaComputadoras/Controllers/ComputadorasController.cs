using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Concreto;
using Dominio.Abstracto;
using Dominio.Modelo;

namespace WebUI.Areas.AreaComputadoras.Controllers
{
    public class ComputadorasController : Controller
    {
        private IComputadorasRepositorio repositorio;
        public int paginaTamaño = 15;

        // GET: AreaComputadoras/Computadoras
        public ActionResult Index()
        {
            return View();
        }

        public ComputadorasController(IComputadorasRepositorio repo)
        {
            repositorio = repo;
        }

        public ViewResult ComputadorasLista(int pagina = 1,int Numitems = 15,string orden="asc")
        {

        }

    }
}