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
    public class ClienteController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: Cliente
        public ActionResult Index()
        {
            var lista = db.SP_MostrarClienteTodo().ToList();
            return View(lista);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var cliente = db.Database.SqlQuery<cliente>
                ("SP_BuscarClienteXCodigo @codigo", pid).FirstOrDefault();
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.coddis = new SelectList(
                db.Database.SqlQuery<distrito>("SP_MostrarDistrito").ToList(),
                "coddis", "nomdis"
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

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codcli,nomcli,apepcli,apemcli,doccli,dircli,telcli,celcli,corcli,estcli,coddis,codtipd,codsex")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "SP_RegistrarCliente @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11",
                    cliente.nomcli,
                    cliente.apepcli,
                    cliente.apemcli,
                    cliente.doccli,
                    cliente.dircli,
                    cliente.telcli,
                    cliente.celcli,
                    cliente.corcli,
                    cliente.estcli,
                    cliente.coddis,
                    cliente.codtipd,
                    cliente.codsex
                    );
                return RedirectToAction("Index");
            }

            ViewBag.coddis = new SelectList(
                db.Database.SqlQuery<distrito>("SP_MostrarDistrito").ToList(),
                "coddis", "nomdis"
                );
            ViewBag.codsex = new SelectList(
                db.Database.SqlQuery<sexo>("SP_MostrarSexo").ToList(),
                "codsex", "nomsex"
                );
            ViewBag.codtipd = new SelectList(
                db.Database.SqlQuery<tipodocumento>("SP_MostrarTipoDocumento").ToList(),
                "codtipd", "nomtipd"
                );
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var cliente = db.Database.SqlQuery<cliente>
                ("SP_BuscarClienteXCodigo @codigo", pid).FirstOrDefault();
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.coddis = new SelectList(
                db.Database.SqlQuery<distrito>("SP_MostrarDistrito").ToList(),
                "coddis", "nomdis"
                );
            ViewBag.codsex = new SelectList(
                db.Database.SqlQuery<sexo>("SP_MostrarSexo").ToList(),
                "codsex", "nomsex"
                );
            ViewBag.codtipd = new SelectList(
                db.Database.SqlQuery<tipodocumento>("SP_MostrarTipoDocumento").ToList(),
                "codtipd", "nomtipd"
                );
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codcli,nomcli,apepcli,apemcli,doccli,dircli,telcli,celcli,corcli,estcli,coddis,codtipd,codsex")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "SP_ActualizarCliente @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12",
                    cliente.codcli,
                    cliente.nomcli,
                    cliente.apepcli,
                    cliente.apemcli,
                    cliente.doccli,
                    cliente.dircli,
                    cliente.telcli,
                    cliente.celcli,
                    cliente.corcli,
                    cliente.estcli,
                    cliente.coddis,
                    cliente.codtipd,
                    cliente.codsex
                    );
                return RedirectToAction("Index");
            }
            ViewBag.coddis = new SelectList(
                db.Database.SqlQuery<distrito>("SP_MostrarDistrito").ToList(),
                "coddis", "nomdis"
                );
            ViewBag.codsex = new SelectList(
                db.Database.SqlQuery<sexo>("SP_MostrarSexo").ToList(),
                "codsex", "nomsex"
                );
            ViewBag.codtipd = new SelectList(
                db.Database.SqlQuery<tipodocumento>("SP_MostrarTipoDocumento").ToList(),
                "codtipd", "nomtipd"
                );
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var cliente = db.Database.SqlQuery<cliente>
                ("SP_BuscarClienteXCodigo @codigo", pid).FirstOrDefault();
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Database.ExecuteSqlCommand(
                "SP_EliminarCliente @p0", id
                );
            return RedirectToAction("Index");
        }

        // GET: Cliente/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var cliente = db.Database.SqlQuery<cliente>
                ("SP_BuscarClienteXCodigo @codigo", pid).FirstOrDefault();
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Enable/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public ActionResult EnableConfirmed(int id)
        {
            db.Database.ExecuteSqlCommand(
                "SP_HabilitarCliente @p0", id
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
