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
    public class EmpleadoController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: Empleado
        public ActionResult Index()
        {
            var lista = db.Database.SqlQuery<empleado>("SP_MostrarEmpleadoTodo").ToList();
            return View(lista);
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var empleado = db.Database.SqlQuery<empleado>
                ("SP_BuscarEmpleadoXCodigo @codigo", pid).FirstOrDefault();
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.coddis = new SelectList(
                db.Database.SqlQuery<distrito>("SP_MostrarDistrito").ToList(),
                "coddis", "nomdis"
                );
            ViewBag.codrol = new SelectList(
                db.Database.SqlQuery<rol>("SP_MostrarRol").ToList(),
                "codrol", "nomrol"
                );
            ViewBag.codsex = new SelectList(
                db.Database.SqlQuery<sexo>("SP_MostrarSexo").ToList(),
                "codsex", "nomsex"
                );
            ViewBag.codtipd = new SelectList(
                db.Database.SqlQuery<tipodocumento>("SP_MostrarTipoDocumento").ToList(),
                "codtipd", "nomtipd"
                );
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codemp,nomemp,apepemp,apememp,docemp,diremp,telemp,celemp,coremp,usuemp,claemp,estemp,coddis,codrol,codtipd,codsex")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "SP_RegistrarEmpleado @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14",
                    empleado.nomemp,
                    empleado.apepemp,
                    empleado.apememp,
                    empleado.docemp,
                    empleado.diremp,
                    empleado.telemp,
                    empleado.celemp,
                    empleado.coremp,
                    empleado.usuemp,
                    empleado.claemp,
                    empleado.estemp,
                    empleado.coddis,
                    empleado.codrol,
                    empleado.codtipd,
                    empleado.codsex
                    );
                return RedirectToAction("Index");
            }

            ViewBag.coddis = new SelectList(
                db.Database.SqlQuery<distrito>("SP_MostrarDistrito").ToList(),
                "coddis", "nomdis"
                );
            ViewBag.codrol = new SelectList(
                db.Database.SqlQuery<rol>("SP_MostrarRol").ToList(),
                "codrol", "nomrol"
                );
            ViewBag.codsex = new SelectList(
                db.Database.SqlQuery<sexo>("SP_MostrarSexo").ToList(),
                "codsex", "nomsex"
                );
            ViewBag.codtipd = new SelectList(
                db.Database.SqlQuery<tipodocumento>("SP_MostrarTipoDocumento").ToList(),
                "codtipd", "nomtipd"
                );
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var empleado = db.Database.SqlQuery<empleado>
                ("SP_BuscarEmpleadoXCodigo @codigo", pid).FirstOrDefault();
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.coddis = new SelectList(
                db.Database.SqlQuery<distrito>("SP_MostrarDistrito").ToList(),
                "coddis", "nomdis"
                );
            ViewBag.codrol = new SelectList(
                db.Database.SqlQuery<rol>("SP_MostrarRol").ToList(),
                "codrol", "nomrol"
                );
            ViewBag.codsex = new SelectList(
                db.Database.SqlQuery<sexo>("SP_MostrarSexo").ToList(),
                "codsex", "nomsex"
                );
            ViewBag.codtipd = new SelectList(
                db.Database.SqlQuery<tipodocumento>("SP_MostrarTipoDocumento").ToList(),
                "codtipd", "nomtipd"
                );
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codemp,nomemp,apepemp,apememp,docemp,diremp,telemp,celemp,coremp,usuemp,claemp,estemp,coddis,codrol,codtipd,codsex")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "SP_ActualizarEmpleado @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15",
                    empleado.codemp,
                    empleado.nomemp,
                    empleado.apepemp,
                    empleado.apememp,
                    empleado.docemp,
                    empleado.diremp,
                    empleado.telemp,
                    empleado.celemp,
                    empleado.coremp,
                    empleado.usuemp,
                    empleado.claemp,
                    empleado.estemp,
                    empleado.coddis,
                    empleado.codrol,
                    empleado.codtipd,
                    empleado.codsex
                    );
                return RedirectToAction("Index");
            }
            ViewBag.coddis = new SelectList(
                db.Database.SqlQuery<distrito>("SP_MostrarDistrito").ToList(),
                "coddis", "nomdis"
                );
            ViewBag.codrol = new SelectList(
                db.Database.SqlQuery<rol>("SP_MostrarRol").ToList(),
                "codrol", "nomrol"
                );
            ViewBag.codsex = new SelectList(
                db.Database.SqlQuery<sexo>("SP_MostrarSexo").ToList(),
                "codsex", "nomsex"
                );
            ViewBag.codtipd = new SelectList(
                db.Database.SqlQuery<tipodocumento>("SP_MostrarTipoDocumento").ToList(),
                "codtipd", "nomtipd"
                );
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var empleado = db.Database.SqlQuery<empleado>
                ("SP_BuscarEmpleadoXCodigo @codigo", pid).FirstOrDefault();
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Database.ExecuteSqlCommand(
                "SP_EliminarEmpleado @p0", id
                );
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Empleado/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var empleado = db.Database.SqlQuery<empleado>
                ("SP_BuscarEmpleadoXCodigo @codigo", pid).FirstOrDefault();
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Enable/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public ActionResult EnableConfirmed(int id)
        {
            db.Database.ExecuteSqlCommand(
                "SP_HabilitarEmpleado @p0", id
                );
            return RedirectToAction("Index");
        }
            db.SaveChanges();
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
