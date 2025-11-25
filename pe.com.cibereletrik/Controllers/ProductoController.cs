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
    public class ProductoController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: Producto
        public ActionResult Index()
        {
            var lista = db.SP_MostrarProductoTodo().ToList();
            return View(lista);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var producto = db.Database.SqlQuery<producto>
                ("SP_BuscarProductoXCodigo @codigo", pid).FirstOrDefault();
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.codcat = new SelectList(
                db.Database.SqlQuery<categoria>("SP_MostrarCategoria").ToList(),
                "codcat", "nomcat"
                );
            ViewBag.codmar = new SelectList(
                db.Database.SqlQuery<marca>("SP_MostrarMarca").ToList(),
                "codmar", "nommar"
                );
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codpro,nompro,despro,prepro,canpro,fecing,estpro,codcat,codmar")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "SP_RegistrarProducto @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7",
                    producto.nompro,
                    producto.despro,
                    producto.prepro,
                    producto.canpro,
                    producto.fecing,
                    producto.estpro,
                    producto.codcat,
                    producto.codmar
                    );
                return RedirectToAction("Index");
            }

            ViewBag.codcat = new SelectList(
                db.Database.SqlQuery<categoria>("SP_MostrarCategoria").ToList(),
                "codcat", "nomcat"
                );
            ViewBag.codmar = new SelectList(
                db.Database.SqlQuery<marca>("SP_MostrarMarca").ToList(),
                "codmar", "nommar"
                );
            return View(producto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var producto = db.Database.SqlQuery<producto>
                ("SP_BuscarProductoXCodigo @codigo", pid).FirstOrDefault();
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.codcat = new SelectList(
                db.Database.SqlQuery<categoria>("SP_MostrarCategoria").ToList(),
                "codcat", "nomcat"
                );
            ViewBag.codmar = new SelectList(
                db.Database.SqlQuery<marca>("SP_MostrarMarca").ToList(),
                "codmar", "nommar"
                );
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codpro,nompro,despro,prepro,canpro,fecing,estpro,codcat,codmar")] producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                    "SP_ActualizarProducto @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8",
                    producto.codpro,
                    producto.nompro,
                    producto.despro,
                    producto.prepro,
                    producto.canpro,
                    producto.fecing,
                    producto.estpro,
                    producto.codcat,
                    producto.codmar
                    );
                return RedirectToAction("Index");
            }
            ViewBag.codcat = new SelectList(
                db.Database.SqlQuery<categoria>("SP_MostrarCategoria").ToList(),
                "codcat", "nomcat"
                );
            ViewBag.codmar = new SelectList(
                db.Database.SqlQuery<marca>("SP_MostrarMarca").ToList(),
                "codmar", "nommar"
                );
            return View(producto);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var producto = db.Database.SqlQuery<producto>
                ("SP_BuscarProductoXCodigo @codigo", pid).FirstOrDefault();
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Database.ExecuteSqlCommand(
                "SP_EliminarProducto @p0", id
                );
            return RedirectToAction("Index");
        }

        // GET: Producto/Enable/5
        public ActionResult Enable(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter pid = new SqlParameter("@codigo", id);
            var producto = db.Database.SqlQuery<producto>
                ("SP_BuscarProductoXCodigo @codigo", pid).FirstOrDefault();
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Enable")]
        [ValidateAntiForgeryToken]
        public ActionResult EnableConfirmed(int id)
        {
            db.Database.ExecuteSqlCommand(
                "SP_HabilitarProducto @p0", id
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
