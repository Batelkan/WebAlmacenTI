using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dominio.Modelo;
using Dominio.Concreto;
using Dominio.Abstracto;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AdminSuministroController : Controller
    {
       private ISuministroRespositorio repositorio;
        public AdminSuministroController(ISuministroRespositorio repo)
        {
            repositorio = repo;
        }
        // GET: AdminSuministro
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Editar(int id)
        {
            AdminSuministroViewModel modelo = new AdminSuministroViewModel();
            modelo.suministro = repositorio.Suministros.FirstOrDefault(s => s.ID == id);
            modelo.categoria = repositorio.categoria.Select(c => new SelectListItem() { Text = c.Tipo1.ToString() });
            return View("Index",modelo);
        }
    }
}