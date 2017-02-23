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

    }
}