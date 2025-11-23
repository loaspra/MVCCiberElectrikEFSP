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
    public class TicketPedidoController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: TicketPedido
        public ActionResult Index()
        {
            var ticketpedido = db.ticketpedido.Include(t => t.cliente).Include(t => t.empleado);
            return View(ticketpedido.ToList());
        }

        // GET: TicketPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticketpedido ticketpedido = db.ticketpedido.Find(id);
            if (ticketpedido == null)
            {
                return HttpNotFound();
            }
            return View(ticketpedido);
        }

        // GET: TicketPedido/Create
        public ActionResult Create()
        {
            ViewBag.codcli = new SelectList(db.cliente, "codcli", "nomcli");
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp");
            return View();
        }

        // POST: TicketPedido/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nroped,fecped,codemp,codcli,estped")] ticketpedido ticketpedido)
        {
            if (ModelState.IsValid)
            {
                db.ticketpedido.Add(ticketpedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codcli = new SelectList(db.cliente, "codcli", "nomcli", ticketpedido.codcli);
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp", ticketpedido.codemp);
            return View(ticketpedido);
        }

        // GET: TicketPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticketpedido ticketpedido = db.ticketpedido.Find(id);
            if (ticketpedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.codcli = new SelectList(db.cliente, "codcli", "nomcli", ticketpedido.codcli);
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp", ticketpedido.codemp);
            return View(ticketpedido);
        }

        // POST: TicketPedido/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nroped,fecped,codemp,codcli,estped")] ticketpedido ticketpedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketpedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codcli = new SelectList(db.cliente, "codcli", "nomcli", ticketpedido.codcli);
            ViewBag.codemp = new SelectList(db.empleado, "codemp", "nomemp", ticketpedido.codemp);
            return View(ticketpedido);
        }

        // GET: TicketPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticketpedido ticketpedido = db.ticketpedido.Find(id);
            if (ticketpedido == null)
            {
                return HttpNotFound();
            }
            return View(ticketpedido);
        }

        // POST: TicketPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ticketpedido ticketpedido = db.ticketpedido.Find(id);
            db.ticketpedido.Remove(ticketpedido);
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
