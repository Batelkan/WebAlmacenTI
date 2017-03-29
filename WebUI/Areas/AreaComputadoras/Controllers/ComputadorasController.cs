using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Concreto;
using Dominio.Abstracto;
using Dominio.Modelo;
using WebUI.Areas.AreaComputadoras.Models;
using WebUI.Infraestructura1;

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

        public ViewResult ComputadorasLista( int pagina = 1, int Numitems = 15, string orden = "asc" )
        {
            ComputadoraViewModel modelo = new ComputadoraViewModel()
            {
                PaginaInfo = new WebUI.Models.PaginacionInfo
                {
                    PaginaActual = pagina,
                    ItemPorPagina = Numitems,
                    ItemsTotales = repositorio.Computo.Count()
            
                },
                itemsPorPagina = Numitems,
                OrdenFecha = orden
                
            };

            if(orden == "asc")
            {
                modelo.ListaComputadoras = repositorio.Computo
                    .OrderBy(c => c.FechaAlta)
                    .Skip((pagina - 1) * Numitems)
                    .Take(Numitems);
            }
          else
            {
                modelo.ListaComputadoras = repositorio.Computo
                  .OrderByDescending(c => c.FechaAlta)
                  .Skip((pagina - 1) * Numitems)
                  .Take(Numitems);
            }
            return View(modelo);
        }

    }
}