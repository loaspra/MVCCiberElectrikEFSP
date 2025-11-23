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
    public class EmpleadoController : Controller
    {
        private bdciberelectrik2026Entities db = new bdciberelectrik2026Entities();

        // GET: Empleado
        public ActionResult Index()
        {
            var empleado = db.empleado.Include(e => e.distrito).Include(e => e.rol).Include(e => e.sexo).Include(e => e.tipodocumento);
            return View(empleado.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis");
            ViewBag.codrol = new SelectList(db.rol, "codrol", "nomrol");
            ViewBag.codsex = new SelectList(db.sexo, "codsex", "nomsex");
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codtipd", "nomtipd");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codemp,nomemp,apepemp,apememp,docemp,diremp,telemp,celemp,coremp,usuemp,claemp,estemp,coddis,codrol,codtipd,codsex")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codrol", "nomrol", empleado.codrol);
            ViewBag.codsex = new SelectList(db.sexo, "codsex", "nomsex", empleado.codsex);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codtipd", "nomtipd", empleado.codtipd);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codrol", "nomrol", empleado.codrol);
            ViewBag.codsex = new SelectList(db.sexo, "codsex", "nomsex", empleado.codsex);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codtipd", "nomtipd", empleado.codtipd);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codemp,nomemp,apepemp,apememp,docemp,diremp,telemp,celemp,coremp,usuemp,claemp,estemp,coddis,codrol,codtipd,codsex")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.coddis = new SelectList(db.distrito, "coddis", "nomdis", empleado.coddis);
            ViewBag.codrol = new SelectList(db.rol, "codrol", "nomrol", empleado.codrol);
            ViewBag.codsex = new SelectList(db.sexo, "codsex", "nomsex", empleado.codsex);
            ViewBag.codtipd = new SelectList(db.tipodocumento, "codtipd", "nomtipd", empleado.codtipd);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
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
            empleado empleado = db.empleado.Find(id);
            db.empleado.Remove(empleado);
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
