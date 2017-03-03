using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using Dominio.Concreto;
using Dominio.Abstracto;
using Dominio.Modelo;

namespace WebUI.Controllers
{
    public class SuministroController : Controller
    {
        private ISuministroRespositorio repositorio;
        public int paginaTamaño = 15;
        // GET: Suministro
        
       public SuministroController(ISuministroRespositorio repo)
        {
            repositorio = repo;
        
        }

        public ViewResult SuministrosLista(int pagina = 1, int NumItems = 15,string orden = "asc")
        {
            SuministroViewModel model = new SuministroViewModel()
            {
                PaginaInfo = new PaginacionInfo
                {
                    PaginaActual = pagina,
                    ItemPorPagina = NumItems,
                    ItemsTotales = repositorio.Suministros.Count()
                },
                itemsPorPagina = NumItems,
                OrdenFecha = orden
            };

            if (orden == "asc")
            {
                model.ListaArticulos = repositorio.Suministros
                .OrderBy(s => s.FechaAlta)
                .Skip((pagina - 1) * NumItems)
                .Take(NumItems);
            }
          else
            {
                model.ListaArticulos = repositorio.Suministros
               .OrderByDescending(s => s.FechaAlta)
               .Skip((pagina - 1) * NumItems)
               .Take(NumItems);
            }
            return View(model);
        }

        public ViewResult SuministroBusqueda(SuministroViewModel modelo)
        {
            if(modelo.terminoBusqueda == null)
            {
                SuministroViewModel modIfEmpty = new SuministroViewModel()
                {
                    ListaArticulos = repositorio.Suministros
                      .OrderBy(s => s.FechaAlta)
                      .Skip((1 - 1) * 15)
                      .Take(15),
                    PaginaInfo = new PaginacionInfo
                    {
                        PaginaActual = 1,
                        ItemPorPagina = 15,
                        ItemsTotales = repositorio.Suministros.Count()
                    },
                    itemsPorPagina = 15
                };

                return View("SuministrosLista", modIfEmpty);
            }



            SuministroViewModel mod = new SuministroViewModel();
            mod.itemsPorPagina = 15;

            switch (modelo.CampoBusqueda)
            {
                case "Categoria":
                    mod.ListaArticulos = repositorio.Suministros
                        .Where(s => s.Tipo.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                        .OrderByDescending(s => s.FechaAlta);
                    break;
                case "Factura":
                    mod.ListaArticulos = repositorio.Suministros
                     .Where(s => s.Factura.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                     .OrderByDescending(s => s.FechaAlta);
                
                    break;
                case "Disponibilidad":
                    mod.ListaArticulos = repositorio.Suministros
                    .Where(s => s.Estatus.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                    .OrderByDescending(s => s.FechaAlta);
                    break;
                case "Modelo":
                    mod.ListaArticulos = repositorio.Suministros
                     .Where(s => s.Modelo.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                     .OrderByDescending(s => s.FechaAlta);
                    break;
                case "Fabricante":
                    mod.ListaArticulos = repositorio.Suministros
                     .Where(s => s.Fabricante.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                     .OrderByDescending(s => s.FechaAlta);
                    break;
                default:
                    mod.ListaArticulos = repositorio.Suministros
                      .OrderByDescending(s => s.FechaAlta)
                      .Skip((1 - 1) * mod.itemsPorPagina)
                      .Take(mod.itemsPorPagina);
                    break;

            }

            if (!mod.ListaArticulos.Any())
            {
                mod.ListaArticulos = repositorio.Suministros
                   .OrderByDescending(s => s.FechaAlta)
                   .Skip((1 - 1) * 15)
                   .Take(15);
                mod.PaginaInfo = new PaginacionInfo
                {
                    PaginaActual = 1,
                    ItemPorPagina = 15,
                    ItemsTotales = repositorio.Suministros.Count()
                };

            }

            else
            {
                mod.PaginaInfo = new PaginacionInfo
                {
                    PaginaActual = 1,
                    ItemPorPagina = mod.ListaArticulos.Count(),
                    ItemsTotales = mod.ListaArticulos.Count()
                };
            }

            return View("SuministrosLista",mod);
        }

        

    }
}