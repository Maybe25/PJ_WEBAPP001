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
    public class DistritoController : Controller
    {
        private BD_ActivoFijosEntities db = new BD_ActivoFijosEntities();

        // GET: Distrito
        public ActionResult Index()
        {
            return View(db.DISTRITO.ToList());
        }

        // GET: Distrito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRITO dISTRITO = db.DISTRITO.Find(id);
            if (dISTRITO == null)
            {
                return HttpNotFound();
            }
            return View(dISTRITO);
        }

        // GET: Distrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distrito/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDE_DIS,DES_DIS")] DISTRITO dISTRITO)
        {
            if (ModelState.IsValid)
            {
                db.DISTRITO.Add(dISTRITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dISTRITO);
        }

        // GET: Distrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRITO dISTRITO = db.DISTRITO.Find(id);
            if (dISTRITO == null)
            {
                return HttpNotFound();
            }
            return View(dISTRITO);
        }

        // POST: Distrito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDE_DIS,DES_DIS")] DISTRITO dISTRITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dISTRITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dISTRITO);
        }

        // GET: Distrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DISTRITO dISTRITO = db.DISTRITO.Find(id);
            if (dISTRITO == null)
            {
                return HttpNotFound();
            }
            return View(dISTRITO);
        }

        // POST: Distrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DISTRITO dISTRITO = db.DISTRITO.Find(id);
            db.DISTRITO.Remove(dISTRITO);
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
