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
            ViewBag.IDsuministro = id;
            ViewBag.Operacion = "Editar";
            return View("Index",modelo);
        }

        public ActionResult Crear()
        {
            ViewBag.IDsuministro = "";
            ViewBag.Operacion = "Nuevo Suministro";
            return View("Index", new AdminSuministroViewModel() { suministro = new Articulos() {FechaAlta = DateTime.Now } ,categoria = repositorio.categoria.Select(c => new SelectListItem() { Text = c.Tipo1.ToString() }) });
        }

        [HttpPost]
        public ActionResult Editar(Articulos suministro)
        {
            if(ModelState.IsValid)
            {
                repositorio.SalvarSuminnistro(suministro);
                TempData["MensajeAdmin"] = "Suministro Guardado con Exito !";
                return View("Index", new AdminSuministroViewModel() {suministro = suministro,categoria = repositorio.categoria.Select(c => new SelectListItem() { Text = c.Tipo1.ToString() }) });
            }
            return View("Index", new AdminSuministroViewModel() { suministro = suministro, categoria = repositorio.categoria.Select(c => new SelectListItem() { Text = c.Tipo1.ToString() }) });
        }

        public ActionResult Borrar(Articulos suministro )
        {
            repositorio.BorrarSuminnistro(suministro);

            return JavaScript("function () { window.close(); }");
        }

    }
}