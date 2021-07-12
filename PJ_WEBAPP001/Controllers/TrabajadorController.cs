using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PJ_WEBAPP001.Models;
using PJ_WEBAPP001.Filters;

using System.Web.Helpers;
using System.Data.Entity;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace PJ_WEBAPP001.Controllers
{
    public class TrabajadorController : Controller
    {
        BD_ActivoFijosEntities db = new BD_ActivoFijosEntities();
        // GET: Trabajador
        public ActionResult Index()
        {
            return View(db.TRABAJADOR.ToList());
        }

        public ActionResult obtenerImagen(int id)
        {
            TRABAJADOR persona = db.TRABAJADOR.Find(id);
            byte[] byteImagen = persona.IMG_VEN;

            MemoryStream memoria = new MemoryStream(byteImagen);
            Image imagen = Image.FromStream(memoria);

            memoria = new MemoryStream();
            imagen.Save(memoria, ImageFormat.Jpeg);
            memoria.Position = 0;

            return File(memoria, "image/");
        }

        [AuthorizeUser(idOperacion: 2)]
        public ActionResult Create()
        {
            ViewBag.IDE_DIS = new SelectList(db.DISTRITO, "IDE_DIS", "DES_DIS");
            return View(new TRABAJADOR());
        }

        [HttpPost]
        public ActionResult Create(TRABAJADOR obj)
        {
            HttpPostedFileBase archivo = Request.Files[0];

            if (archivo.ContentLength == 0)
            {
                ModelState.AddModelError("foto", "Es Necesario seleccionar una imagen...");
                return View(obj);
            }
            else
            {
                if (archivo.FileName.EndsWith(".jpg"))
                {

                    WebImage imagen = new WebImage(archivo.InputStream);
                    obj.IMG_VEN = imagen.GetBytes();

                }
                else
                {
                    ModelState.AddModelError("foto", "Solo se permite imagenes con formato JPG...");
                    return View(obj);
                }

            }

            db.TRABAJADOR.Add(obj);
            db.SaveChanges();
            ViewBag.IDE_DIS = new SelectList(db.DISTRITO, "IDE_DIS", "DES_DIS", obj.IDE_DIS);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            TRABAJADOR persona = db.TRABAJADOR.Find(id);
            ViewBag.IDE_DIS = new SelectList(db.DISTRITO, "IDE_DIS", "DES_DIS",persona.IDE_DIS);

            return View(persona);
        }
        [HttpPost]
        public ActionResult Edit(TRABAJADOR obj)
        {
            TRABAJADOR _persona = new TRABAJADOR();

            HttpPostedFileBase archivo = Request.Files[0];
            if (archivo.ContentLength == 0)
            {
                _persona = db.TRABAJADOR.Find(obj.IDE_TRA);
                obj.IMG_VEN = _persona.IMG_VEN;

            }
            else
            {
                if (archivo.FileName.EndsWith(".jpg"))
                {
                    WebImage imagen = new WebImage(archivo.InputStream);
                    obj.IMG_VEN = imagen.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("foto", "Solo se permite imagenes con formato JPG...");
                    return View(db.TRABAJADOR.Find(obj.IDE_TRA));
                }
            }
            WebImage image = new WebImage(archivo.InputStream);
            obj.IMG_VEN = image.GetBytes();

            if (ModelState.IsValid)
            {
                db.Entry(_persona).State = EntityState.Detached;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            TRABAJADOR persona = db.TRABAJADOR.Find(id);

            return View(persona);
        }
    }
}