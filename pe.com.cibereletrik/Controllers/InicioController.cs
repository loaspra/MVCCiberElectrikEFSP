using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pe.com.cibereletrik;

namespace pe.com.cibereletrik.Controllers
{
    public class InicioController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        // POST: Inicio/ValidarUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidarUsuario(string usuario, string clave)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                ViewBag.Mensaje = "Debe ingresar usuario y clave";
                return View("Index");
            }

            // Buscar el empleado en la base de datos
            var empleado = db.empleado.FirstOrDefault(e => e.usuemp == usuario && e.claemp == clave);

            // Validar si existe el empleado
            if (empleado == null)
            {
                ViewBag.Mensaje = "Usuario o clave incorrectos";
                return View("Index");
            }

            // Validar si está activo
            if (empleado.estemp == false || empleado.estemp == null)
            {
                ViewBag.Mensaje = "Usuario inactivo";
                return View("Index");
            }

            // Guardar el empleado en sesión
            Session["empleado"] = empleado;
            Session["nombreEmpleado"] = empleado.nomemp;

            // Redirigir al inicio del sistema
            return RedirectToAction("Index", "Home");
        }

        // GET: Inicio/CerrarSesion
        public ActionResult CerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("Index", "Inicio");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
