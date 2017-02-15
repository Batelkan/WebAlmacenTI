using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using Dominio.Modelo;
using Dominio.Concreto;
using Dominio.Abstracto;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IWebAdminUsers repositorio;
        // GET: Login

        public LoginController(IWebAdminUsers repo)
        {
            repositorio = repo;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(WebAdminUser usr)
        {
            //var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                var obj = repositorio.WebAdmin.Where(x => x.Correo.Equals(usr.Correo) && x.contraseña.Equals(usr.contraseña)).FirstOrDefault();
                    if (obj != null)
                    {
                        return Redirect("/Suministro/SuministrosLista");
                    }
            }
            TempData["message"] = "Usuario ó contraseña invalida";
            return View(usr);
           
        }


    }
}