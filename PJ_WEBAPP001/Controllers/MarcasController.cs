using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PJ_WEBAPP001.Models;

namespace PJ_WEBAPP001.Controllers
{
    public class MarcasController : Controller
    {
        private BD_ActivoFijosEntities db = new BD_ActivoFijosEntities();

        // GET: Marcas
        public ActionResult Index()
        {
            return View(db.MARCAS.ToList());
        }

        // GET: Marcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCAS mARCAS = db.MARCAS.Find(id);
            if (mARCAS == null)
            {
                return HttpNotFound();
            }
            return View(mARCAS);
        }

        // GET: Marcas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDE_MAR,DES_MAR")] MARCAS mARCAS)
        {
            if (ModelState.IsValid)
            {
                db.MARCAS.Add(mARCAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mARCAS);
        }

        // GET: Marcas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCAS mARCAS = db.MARCAS.Find(id);
            if (mARCAS == null)
            {
                return HttpNotFound();
            }
            return View(mARCAS);
        }

        // POST: Marcas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDE_MAR,DES_MAR")] MARCAS mARCAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mARCAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mARCAS);
        }

        // GET: Marcas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MARCAS mARCAS = db.MARCAS.Find(id);
            if (mARCAS == null)
            {
                return HttpNotFound();
            }
            return View(mARCAS);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MARCAS mARCAS = db.MARCAS.Find(id);
            db.MARCAS.Remove(mARCAS);
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
