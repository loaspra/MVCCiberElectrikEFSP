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
    public class DetalleTicketPedidoController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: DetalleTicketPedido
        public ActionResult Index()
        {
            var lista = db.SP_MostrarDetalleTicketPedidoTodo().ToList();
            return View(lista);
        }

        // GET: DetalleTicketPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var detalleticketpedido = db.Database.SqlQuery<detalleticketpedido>
                ("SP_BuscarDetalleTicketPedidoXCodigo @codigo", pid).FirstOrDefault();
            if (detalleticketpedido == null)
            {
                return HttpNotFound();
            }
            return View(detalleticketpedido);
        }

        // GET: DetalleTicketPedido/Create
        public ActionResult Create()
        {
            ViewBag.codpro = new SelectList(
                db.Database.SqlQuery<producto>("SP_MostrarProducto").ToList(),
                "codpro", "nompro"
                );
            ViewBag.nroped = new SelectList(db.ticketpedido, "nroped", "nroped");
            return View();
        }

        // POST: DetalleTicketPedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nrodet,canent,preent,nroped,codpro")] detalleticketpedido detalleticketpedido)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "SP_RegistrarDetalleTicketPedido @p0,@p1,@p2,@p3",
                    detalleticketpedido.canent,
                    detalleticketpedido.preent,
                    detalleticketpedido.nroped,
                    detalleticketpedido.codpro
                    );
                return RedirectToAction("Index");
            }

            ViewBag.codpro = new SelectList(
                db.Database.SqlQuery<producto>("SP_MostrarProducto").ToList(),
                "codpro", "nompro"
                );
            ViewBag.nroped = new SelectList(db.ticketpedido, "nroped", "nroped");
            return View(detalleticketpedido);
        }

        // GET: DetalleTicketPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var detalleticketpedido = db.Database.SqlQuery<detalleticketpedido>
                ("SP_BuscarDetalleTicketPedidoXCodigo @codigo", pid).FirstOrDefault();
            if (detalleticketpedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.codpro = new SelectList(
                db.Database.SqlQuery<producto>("SP_MostrarProducto").ToList(),
                "codpro", "nompro"
                );
            ViewBag.nroped = new SelectList(db.ticketpedido, "nroped", "nroped");
            return View(detalleticketpedido);
        }

        // POST: DetalleTicketPedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nrodet,canent,preent,nroped,codpro")] detalleticketpedido detalleticketpedido)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "SP_ActualizarDetalleTicketPedido @p0,@p1,@p2,@p3,@p4",
                    detalleticketpedido.nrodet,
                    detalleticketpedido.canent,
                    detalleticketpedido.preent,
                    detalleticketpedido.nroped,
                    detalleticketpedido.codpro
                    );
                return RedirectToAction("Index");
            }
            ViewBag.codpro = new SelectList(
                db.Database.SqlQuery<producto>("SP_MostrarProducto").ToList(),
                "codpro", "nompro"
                );
            ViewBag.nroped = new SelectList(db.ticketpedido, "nroped", "nroped");
            return View(detalleticketpedido);
        }

        // GET: DetalleTicketPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var detalleticketpedido = db.Database.SqlQuery<detalleticketpedido>
                ("SP_BuscarDetalleTicketPedidoXCodigo @codigo", pid).FirstOrDefault();
            if (detalleticketpedido == null)
            {
                return HttpNotFound();
            }
            return View(detalleticketpedido);
        }

        // POST: DetalleTicketPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Database.ExecuteSqlCommand(
                "SP_EliminarDetalleTicketPedido @p0", id
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
