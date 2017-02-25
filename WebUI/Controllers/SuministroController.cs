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

        public ViewResult SuministrosLista(int pagina = 1, int NumItems = 15)
        {
      
            SuministroViewModel model = new SuministroViewModel()
            {
                ListaArticulos = repositorio.Suministros
                
                .OrderBy(s => s.FechaAlta)
                .Skip((pagina - 1) * NumItems)
                .Take(NumItems),
                PaginaInfo = new PaginacionInfo
                {
                    PaginaActual = pagina,
                    ItemPorPagina = NumItems,
                    ItemsTotales = repositorio.Suministros.Count()
                },
                itemsPorPagina = NumItems
            };

            return View(model);
        }

        public ViewResult SuministroBusqueda(SuministroViewModel modelo)
        {

            SuministroViewModel mod = new SuministroViewModel();
            mod.itemsPorPagina = 15;
        

            switch (modelo.CampoBusqueda)
            {
                case "Categoria":
                    mod.ListaArticulos = repositorio.Suministros
                        .Where(s => s.Tipo.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                        .OrderByDescending(s => s.FechaAlta)
                        .Skip((1 - 1) * mod.itemsPorPagina)
                        .Take(mod.itemsPorPagina);
                    break;
                case "Factura":
                    mod.ListaArticulos = repositorio.Suministros
                     .Where(s => s.Factura.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                     .OrderByDescending(s => s.FechaAlta)
                     .Skip((1 - 1) * mod.itemsPorPagina)
                     .Take(mod.itemsPorPagina);
                    break;
                case "Disponibilidad":
                    mod.ListaArticulos = repositorio.Suministros
                    .Where(s => s.Estatus.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                    .OrderByDescending(s => s.FechaAlta)
                    .Skip((1 - 1) * mod.itemsPorPagina)
                    .Take(mod.itemsPorPagina);
                    break;
                case "Modelo":
                    mod.ListaArticulos = repositorio.Suministros
                     .Where(s => s.Modelo.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                     .OrderByDescending(s => s.FechaAlta)
                     .Skip((1 - 1) * mod.itemsPorPagina)
                     .Take(mod.itemsPorPagina);
                    break;
                case "Fabricante":
                    mod.ListaArticulos = repositorio.Suministros
                     .Where(s => s.Fabricante.ToLower().Trim() == modelo.terminoBusqueda.ToLower().Trim())
                     .OrderByDescending(s => s.FechaAlta)
                     .Skip((1 - 1) * mod.itemsPorPagina)
                     .Take(mod.itemsPorPagina);
                    break;
                default:
                    mod.ListaArticulos = repositorio.Suministros
                      .OrderByDescending(s => s.FechaAlta)
                      .Skip((1 - 1) * mod.itemsPorPagina)
                      .Take(mod.itemsPorPagina);
                    break;

            }
            mod.PaginaInfo = new PaginacionInfo
            {
                PaginaActual = 1,
                ItemPorPagina = 15,
                ItemsTotales = mod.ListaArticulos.Count()
            };
            // @model SearchViewModel

            // @using(Html.BeginForm())
            // {
            //                @Html.LabelFor(x => x.Query)
            //    @Html.EditorFor(x => x.Query)
            //    @Html.ValidationMessageFor(x => x.Query)
            //    < button type = "submit" > Search </ button >
            // }

            return View("SuministrosLista",mod);
        }

    }
}