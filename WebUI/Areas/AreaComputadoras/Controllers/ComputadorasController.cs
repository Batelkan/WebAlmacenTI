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


        public ViewResult ComputoBusqueda( ComputadoraViewModel modelo )
        {
            if (modelo.terminoBusqueda == null)
            {
                ComputadoraViewModel modIfEmpty = new ComputadoraViewModel()
                {
                   ListaComputadoras = repositorio.Computo
                      .OrderBy(s => s.FechaAlta)
                      .Skip((1 - 1) * 15)
                      .Take(15),
                    PaginaInfo = new WebUI.Models.PaginacionInfo
                    {
                        PaginaActual = 1,
                        ItemPorPagina = 15,
                        ItemsTotales = repositorio.Computo.Count()
                    },
                    itemsPorPagina = 15
                };

                return View("ComputadorasLista", modIfEmpty);
            }



            ComputadoraViewModel mod = new ComputadoraViewModel();
            mod.itemsPorPagina = 15;

            switch (modelo.CampoBusqueda)
            {
                case "Categoria":
                    mod.ListaComputadoras = repositorio.Computo
                        .Where(s => s.Tipo.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                        .OrderByDescending(s => s.FechaAlta);
                    break;
                case "Factura":
                    mod.ListaComputadoras = repositorio.Computo
                     .Where(s => s.factura.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                     .OrderByDescending(s => s.FechaAlta);

                    break;
                case "Disponibilidad":
                    mod.ListaComputadoras = repositorio.Computo
                    .Where(s => s.Estatus.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                    .OrderByDescending(s => s.FechaAlta);
                    break;
                case "Modelo":
                    mod.ListaComputadoras = repositorio.Computo
                     .Where(s => s.modelo.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                     .OrderByDescending(s => s.FechaAlta);
                    break;
                case "Fabricante":
                    mod.ListaComputadoras = repositorio.Computo
                     .Where(s => s.Fabricante.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                     .OrderByDescending(s => s.FechaAlta);
                    break;
                default:
                    mod.ListaComputadoras = repositorio.Computo
                      .OrderByDescending(s => s.FechaAlta)
                      .Skip((1 - 1) * mod.itemsPorPagina)
                      .Take(mod.itemsPorPagina);
                    break;

            }

            if (!mod.ListaComputadoras.Any())
            {
                mod.ListaComputadoras = repositorio.Computo
                   .OrderByDescending(s => s.FechaAlta)
                   .Skip((1 - 1) * 15)
                   .Take(15);
                mod.PaginaInfo = new WebUI.Models.PaginacionInfo
                {
                    PaginaActual = 1,
                    ItemPorPagina = 15,
                    ItemsTotales = repositorio.Computo.Count()
                };

            }

            else
            {
                mod.PaginaInfo = new WebUI.Models.PaginacionInfo
                {
                    PaginaActual = 1,
                    ItemPorPagina = mod.ListaComputadoras.Count(),
                    ItemsTotales = mod.ListaComputadoras.Count()
                };
            }

            return View("ComputadorasLista", mod);
        }



    }
}