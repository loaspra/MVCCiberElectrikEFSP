using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
            var detalleticketpedido = db.detalleticketpedido.Include(d => d.producto).Include(d => d.ticketpedido);
            return View(detalleticketpedido.ToList());
        }

        // GET: DetalleTicketPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleticketpedido detalleticketpedido = db.detalleticketpedido.Find(id);
            if (detalleticketpedido == null)
            {
                return HttpNotFound();
            }
            return View(detalleticketpedido);
        }

        // GET: DetalleTicketPedido/Create
        public ActionResult Create()
        {
            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro");
            ViewBag.nroped = new SelectList(db.ticketpedido, "nroped", "nroped");
            return View();
        }

        // POST: DetalleTicketPedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nrodet,canent,preent,nroped,codpro")] detalleticketpedido detalleticketpedido)
        {
            if (ModelState.IsValid)
            {
                db.detalleticketpedido.Add(detalleticketpedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro", detalleticketpedido.codpro);
            ViewBag.nroped = new SelectList(db.ticketpedido, "nroped", "nroped", detalleticketpedido.nroped);
            return View(detalleticketpedido);
        }

        // GET: DetalleTicketPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleticketpedido detalleticketpedido = db.detalleticketpedido.Find(id);
            if (detalleticketpedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro", detalleticketpedido.codpro);
            ViewBag.nroped = new SelectList(db.ticketpedido, "nroped", "nroped", detalleticketpedido.nroped);
            return View(detalleticketpedido);
        }

        // POST: DetalleTicketPedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nrodet,canent,preent,nroped,codpro")] detalleticketpedido detalleticketpedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleticketpedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codpro = new SelectList(db.producto, "codpro", "nompro", detalleticketpedido.codpro);
            ViewBag.nroped = new SelectList(db.ticketpedido, "nroped", "nroped", detalleticketpedido.nroped);
            return View(detalleticketpedido);
        }

        // GET: DetalleTicketPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalleticketpedido detalleticketpedido = db.detalleticketpedido.Find(id);
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
            detalleticketpedido detalleticketpedido = db.detalleticketpedido.Find(id);
            db.detalleticketpedido.Remove(detalleticketpedido);
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
