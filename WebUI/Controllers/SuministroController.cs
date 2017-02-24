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

        public ViewResult SuministroBusqueda(SuministroViewModel mod)
        {

            switch(mod.CampoBusqueda)
            {
                case "Categoria ":
                    mod.ListaArticulos
                        .OrderByDescending(s => s.FechaAlta)
                        .Where(s => s.Nombre == mod.terminoBusqueda)
                        .Skip((1 - 1) * mod.itemsPorPagina)
                        .Take(mod.itemsPorPagina);
                    break;
                case "Factura":
                    mod.ListaArticulos
                       .OrderByDescending(s => s.FechaAlta)
                       .Where(s => s.Nombre == mod.terminoBusqueda)
                       .Skip((1 - 1) * mod.itemsPorPagina)
                       .Take(mod.itemsPorPagina);
                    break;
                case "Disponibilidad":
                    mod.ListaArticulos
                       .OrderByDescending(s => s.FechaAlta)
                       .Where(s => s.Nombre == mod.terminoBusqueda)
                       .Skip((1 - 1) * mod.itemsPorPagina)
                       .Take(mod.itemsPorPagina);
                    break;
                case "Modelo":
                    mod.ListaArticulos
                       .OrderByDescending(s => s.FechaAlta)
                       .Where(s => s.Nombre == mod.terminoBusqueda)
                       .Skip((1 - 1) * mod.itemsPorPagina)
                       .Take(mod.itemsPorPagina);
                    break;
                case "Fabricante":
                    mod.ListaArticulos
                       .OrderByDescending(s => s.FechaAlta)
                       .Where(s => s.Nombre == mod.terminoBusqueda)
                       .Skip((1 - 1) * mod.itemsPorPagina)
                       .Take(mod.itemsPorPagina);
                    break;
                default:
                    mod.ListaArticulos
                      .OrderByDescending(s => s.FechaAlta)
                      .Skip((1 - 1) * mod.itemsPorPagina)
                      .Take(mod.itemsPorPagina);
                    break;

            }

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