using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pe.com.cibereletrik.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // Validar si el usuario está autenticado
            if (Session["empleado"] == null)
            {
                return RedirectToAction("Index", "Inicio");
            }
            
            return View();
        }
    }
}
