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
    public class TipoDocumentoController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: TipoDocumento
        public ActionResult Index()
        {
            var lista = db.Database.SqlQuery<SP_MostrarTipoDocumentoTodo_Result>("SP_MostrarTipoDocumentoTodo").ToList();
            return View(lista);
        }

        // GET: TipoDocumento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            tipodocumento tipodocumento = db.Database.SqlQuery<tipodocumento>("SP_BuscarTipoDocumentoXCodigo @codigo", codigo).FirstOrDefault();
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        // GET: TipoDocumento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codtipd,nomtipd,esttipd")] tipodocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                var nombre = new SqlParameter("@nombre", tipodocumento.nomtipd);
                var estado = new SqlParameter("@estado", tipodocumento.esttipd);
                db.Database.ExecuteSqlCommand("SP_RegistrarTipoDocumento @nombre, @estado", nombre, estado);
                return RedirectToAction("Index");
            }

            return View(tipodocumento);
        }

        // GET: TipoDocumento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            tipodocumento tipodocumento = db.Database.SqlQuery<tipodocumento>("SP_BuscarTipoDocumentoXCodigo @codigo", codigo).FirstOrDefault();
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        // POST: TipoDocumento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codtipd,nomtipd,esttipd")] tipodocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                var codigo = new SqlParameter("@codigo", tipodocumento.codtipd);
                var nombre = new SqlParameter("@nombre", tipodocumento.nomtipd);
                var estado = new SqlParameter("@estado", tipodocumento.esttipd);
                db.Database.ExecuteSqlCommand("SP_ActualizarTipoDocumento @codigo, @nombre, @estado", codigo, nombre, estado);
                return RedirectToAction("Index");
            }
            return View(tipodocumento);
        }

        // GET: TipoDocumento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            tipodocumento tipodocumento = db.Database.SqlQuery<tipodocumento>("SP_BuscarTipoDocumentoXCodigo @codigo", codigo).FirstOrDefault();
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var codigo = new SqlParameter("@codigo", id);
            db.Database.ExecuteSqlCommand("SP_EliminarTipoDocumento @codigo", codigo);
            return RedirectToAction("Index");
        }

        // GET: TipoDocumento/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            tipodocumento tipodocumento = db.Database.SqlQuery<tipodocumento>("SP_BuscarTipoDocumentoXCodigo @codigo", codigo).FirstOrDefault();
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        // POST: TipoDocumento/Enable/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public ActionResult EnableConfirmed(int id)
        {
            var codigo = new SqlParameter("@codigo", id);
            db.Database.ExecuteSqlCommand("SP_HabilitarTipoDocumento @codigo", codigo);
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
