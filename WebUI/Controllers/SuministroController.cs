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

        public ViewResult SuministrosLista(int pagina = 1)
        {

            SuministroViewModel model = new SuministroViewModel()
            {
                ListaArticulos = repositorio.Suministros
                .OrderBy(s => s.FechaAlta)
                .Skip((pagina - 1) * paginaTamaño)
                .Take(paginaTamaño),
                PaginaInfo = new PaginacionInfo
                {
                    PaginaActual = pagina,
                    ItemPorPagina = paginaTamaño,
                    ItemsTotales = repositorio.Suministros.Count()
                }
            };

            return View(model);
        }

    }
}