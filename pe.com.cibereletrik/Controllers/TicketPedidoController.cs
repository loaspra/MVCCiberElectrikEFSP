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
    public class TicketPedidoController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: TicketPedido
        public ActionResult Index()
        {
            var lista = db.Database.SqlQuery<ticketpedido>("SP_MostrarTicketPedidoTodo").ToList();
            return View(lista);
        }

        // GET: TicketPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            ticketpedido ticketpedido = db.Database.SqlQuery<ticketpedido>("SP_BuscarTicketPedidoXCodigo @codigo", codigo).FirstOrDefault();
            if (ticketpedido == null)
            {
                return HttpNotFound();
            }
            return View(ticketpedido);
        }

        // GET: TicketPedido/Create
        public ActionResult Create()
        {
            ViewBag.codcli = new SelectList(db.cliente.Where(c => c.estcli == true).ToList(), "codcli", "nomcli");
            ViewBag.codemp = new SelectList(db.empleado.Where(e => e.estemp == true).ToList(), "codemp", "nomemp");
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
                var fecha = new SqlParameter("@fecha", ticketpedido.fecped);
                var empleado = new SqlParameter("@empleado", ticketpedido.codemp);
                var cliente = new SqlParameter("@cliente", ticketpedido.codcli);
                var estado = new SqlParameter("@estado", ticketpedido.estped);
                db.Database.ExecuteSqlCommand("SP_RegistrarTicketPedido @fecha, @empleado, @cliente, @estado", 
                    fecha, empleado, cliente, estado);
                return RedirectToAction("Index");
            }

            ViewBag.codcli = new SelectList(db.cliente.Where(c => c.estcli == true).ToList(), "codcli", "nomcli", ticketpedido.codcli);
            ViewBag.codemp = new SelectList(db.empleado.Where(e => e.estemp == true).ToList(), "codemp", "nomemp", ticketpedido.codemp);
            return View(ticketpedido);
        }

        // GET: TicketPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            ticketpedido ticketpedido = db.Database.SqlQuery<ticketpedido>("SP_BuscarTicketPedidoXCodigo @codigo", codigo).FirstOrDefault();
            if (ticketpedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.codcli = new SelectList(db.cliente.Where(c => c.estcli == true).ToList(), "codcli", "nomcli", ticketpedido.codcli);
            ViewBag.codemp = new SelectList(db.empleado.Where(e => e.estemp == true).ToList(), "codemp", "nomemp", ticketpedido.codemp);
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
                var numero = new SqlParameter("@numero", ticketpedido.nroped);
                var fecha = new SqlParameter("@fecha", ticketpedido.fecped);
                var empleado = new SqlParameter("@empleado", ticketpedido.codemp);
                var cliente = new SqlParameter("@cliente", ticketpedido.codcli);
                var estado = new SqlParameter("@estado", ticketpedido.estped);
                db.Database.ExecuteSqlCommand("SP_ActualizarTicketPedido @numero, @fecha, @empleado, @cliente, @estado", 
                    numero, fecha, empleado, cliente, estado);
                return RedirectToAction("Index");
            }
            ViewBag.codcli = new SelectList(db.cliente.Where(c => c.estcli == true).ToList(), "codcli", "nomcli", ticketpedido.codcli);
            ViewBag.codemp = new SelectList(db.empleado.Where(e => e.estemp == true).ToList(), "codemp", "nomemp", ticketpedido.codemp);
            return View(ticketpedido);
        }

        // GET: TicketPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            ticketpedido ticketpedido = db.Database.SqlQuery<ticketpedido>("SP_BuscarTicketPedidoXCodigo @codigo", codigo).FirstOrDefault();
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
            var codigo = new SqlParameter("@codigo", id);
            db.Database.ExecuteSqlCommand("SP_EliminarTicketPedido @codigo", codigo);
            return RedirectToAction("Index");
        }

        // GET: TicketPedido/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var codigo = new SqlParameter("@codigo", id);
            ticketpedido ticketpedido = db.Database.SqlQuery<ticketpedido>("SP_BuscarTicketPedidoXCodigo @codigo", codigo).FirstOrDefault();
            if (ticketpedido == null)
            {
                return HttpNotFound();
            }
            return View(ticketpedido);
        }

        // POST: TicketPedido/Enable/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public ActionResult EnableConfirmed(int id)
        {
            var codigo = new SqlParameter("@codigo", id);
            db.Database.ExecuteSqlCommand("SP_HabilitarTicketPedido @codigo", codigo);
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
