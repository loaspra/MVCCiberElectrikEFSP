using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pe.com.cibereletrik;

namespace pe.com.cibereletrik.Controllers
{
    public class RolController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: Rol
        public ActionResult Index()
        {
            var lista = db.Database.SqlQuery<rol>("SP_MostrarRolTodo").ToList();
            return View(lista);
        }

        // GET: Rol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            rol rol = db.Database.SqlQuery<rol>("SP_BuscarRolXCodigo @codigo", codigo).FirstOrDefault();
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codrol,nomrol,estrol")] rol rol)
        {
            if (ModelState.IsValid)
            {
                var nombre = new SqlParameter("@nombre", rol.nomrol);
                var estado = new SqlParameter("@estado", rol.estrol);
                db.Database.ExecuteSqlCommand("SP_RegistrarRol @nombre, @estado", nombre, estado);
                return RedirectToAction("Index");
            }

            return View(rol);
        }

        // GET: Rol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            rol rol = db.Database.SqlQuery<rol>("SP_BuscarRolXCodigo @codigo", codigo).FirstOrDefault();
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Rol/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codrol,nomrol,estrol")] rol rol)
        {
            if (ModelState.IsValid)
            {
                var codigo = new SqlParameter("@codigo", rol.codrol);
                var nombre = new SqlParameter("@nombre", rol.nomrol);
                var estado = new SqlParameter("@estado", rol.estrol);
                db.Database.ExecuteSqlCommand("SP_ActualizarRol @codigo, @nombre, @estado", codigo, nombre, estado);
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        // GET: Rol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            rol rol = db.Database.SqlQuery<rol>("SP_BuscarRolXCodigo @codigo", codigo).FirstOrDefault();
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var codigo = new SqlParameter("@codigo", id);
            db.Database.ExecuteSqlCommand("SP_EliminarRol @codigo", codigo);
            return RedirectToAction("Index");
        }

        // GET: Rol/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            rol rol = db.Database.SqlQuery<rol>("SP_BuscarRolXCodigo @codigo", codigo).FirstOrDefault();
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Rol/Enable/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public ActionResult EnableConfirmed(int id)
        {
            var codigo = new SqlParameter("@codigo", id);
            db.Database.ExecuteSqlCommand("SP_HabilitarRol @codigo", codigo);
            return RedirectToAction("Index");
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
