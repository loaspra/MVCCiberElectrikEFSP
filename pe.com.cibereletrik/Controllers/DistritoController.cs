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
    public class DistritoController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: Distrito
        public ActionResult Index()
        {
            var lista = db.Database.SqlQuery<distrito>("SP_MostrarDistritoTodo").ToList();
            return View(lista);
        }

        // GET: Distrito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var distrito = db.Database.SqlQuery<distrito>
                ("SP_BuscarDistritoXCodigo @codigo", pid).FirstOrDefault();
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: Distrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distrito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "coddis,nomdis,estdis")] distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "SP_RegistrarDistrito @nombre, @estado",
                    new SqlParameter("@nombre", distrito.nomdis),
                    new SqlParameter("@estado", distrito.estdis)
                    );
                return RedirectToAction("Index");
            }

            return View(distrito);
        }

        // GET: Distrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var distrito = db.Database.SqlQuery<distrito>
                ("SP_BuscarDistritoXCodigo @codigo", pid).FirstOrDefault();
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distrito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "coddis,nomdis,estdis")] distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "SP_ActualizarDistrito @codigo,@nombre, @estado",
                    new SqlParameter("@codigo", distrito.coddis),
                    new SqlParameter("@nombre", distrito.nomdis),
                    new SqlParameter("@estado", distrito.estdis)
                    );
                return RedirectToAction("Index");
            }
            return View(distrito);
        }

        // GET: Distrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var distrito = db.Database.SqlQuery<distrito>
                ("SP_BuscarDistritoXCodigo @codigo", pid).FirstOrDefault();
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Database.ExecuteSqlCommand(
                "SP_EliminarDistrito @codigo",
                new SqlParameter("@codigo", id)
                );
            return RedirectToAction("Index");
        }


        // GET: Distrito/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var distrito = db.Database.SqlQuery<distrito>
                ("SP_BuscarDistritoXCodigo @codigo", pid).FirstOrDefault();
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distrito/Enable/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public ActionResult EnableConfirmed(int id)
        {
            db.Database.ExecuteSqlCommand(
                "SP_HabilitarDistrito @codigo",
                new SqlParameter("@codigo", id)
                );
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
