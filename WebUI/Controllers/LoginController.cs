using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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
                using (InformaticaEntities context = new  InformaticaEntities())
                {
                 
                    var obj = context.WebAdminUser.Where(x => x.Correo.Equals(usr.Correo) && x.contraseña.Equals(usr.contraseña)).FirstOrDefault();
                    if (obj != null)
                    {
                        return RedirectToAction("UserDashBoard");
                    }

                }
            }
            TempData["message"] = "Usuario ó contraseña invalida";
            return View(usr);
           
        }


    }
}