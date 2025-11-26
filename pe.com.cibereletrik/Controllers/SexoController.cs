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
    public class SexoController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: Sexo
        public ActionResult Index()
        {
            var lista = db.Database.SqlQuery<sexo>("SP_MostrarSexoTodo").ToList();
            return View(lista);
        }

        // GET: Sexo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            sexo sexo = db.Database.SqlQuery<sexo>("SP_BuscarSexoXCodigo @codigo", codigo).FirstOrDefault();
            if (sexo == null)
            {
                return HttpNotFound();
            }
            return View(sexo);
        }

        // GET: Sexo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sexo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codsex,nomsex,estsex")] sexo sexo)
        {
            if (ModelState.IsValid)
            {
                var nombre = new SqlParameter("@nombre", sexo.nomsex);
                var estado = new SqlParameter("@estado", sexo.estsex);
                db.Database.ExecuteSqlCommand("SP_RegistrarSexo @nombre, @estado", nombre, estado);
                return RedirectToAction("Index");
            }

            return View(sexo);
        }

        // GET: Sexo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            sexo sexo = db.Database.SqlQuery<sexo>("SP_BuscarSexoXCodigo @codigo", codigo).FirstOrDefault();
            if (sexo == null)
            {
                return HttpNotFound();
            }
            return View(sexo);
        }

        // POST: Sexo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codsex,nomsex,estsex")] sexo sexo)
        {
            if (ModelState.IsValid)
            {
                var codigo = new SqlParameter("@codigo", sexo.codsex);
                var nombre = new SqlParameter("@nombre", sexo.nomsex);
                var estado = new SqlParameter("@estado", sexo.estsex);
                db.Database.ExecuteSqlCommand("SP_ActualizarSexo @codigo, @nombre, @estado", codigo, nombre, estado);
                return RedirectToAction("Index");
            }
            return View(sexo);
        }

        // GET: Sexo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            sexo sexo = db.Database.SqlQuery<sexo>("SP_BuscarSexoXCodigo @codigo", codigo).FirstOrDefault();
            if (sexo == null)
            {
                return HttpNotFound();
            }
            return View(sexo);
        }

        // POST: Sexo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var codigo = new SqlParameter("@codigo", id);
            db.Database.ExecuteSqlCommand("SP_EliminarSexo @codigo", codigo);
            return RedirectToAction("Index");
        }

        // GET: Sexo/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            sexo sexo = db.Database.SqlQuery<sexo>("SP_BuscarSexoXCodigo @codigo", codigo).FirstOrDefault();
            if (sexo == null)
            {
                return HttpNotFound();
            }
            return View(sexo);
        }

        // POST: Sexo/Enable/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public ActionResult EnableConfirmed(int id)
        {
            var codigo = new SqlParameter("@codigo", id);
            db.Database.ExecuteSqlCommand("SP_HabilitarSexo @codigo", codigo);
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
