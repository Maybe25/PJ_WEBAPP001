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
    public class ActivoController : Controller
    {
        BD_ActivoFijosEntities db = new BD_ActivoFijosEntities();
        // GET: Trabajador
        public ActionResult Index()
        {
            return View(db.ACTIVO.ToList());
        }

        public ActionResult obtenerImagen(int id)
        {
            ACTIVO persona = db.ACTIVO.Find(id);
            byte[] byteImagen = persona.IMG_PRO;

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
            ViewBag.IDE_CAT = new SelectList(db.CATEGORIA, "IDE_CAT", "DES_CAT");
            ViewBag.IDE_MAR = new SelectList(db.MARCAS, "IDE_MAR", "DES_MAR");
            return View(new ACTIVO());
        }

        [HttpPost]
        public ActionResult Create(ACTIVO obj)
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
                    obj.IMG_PRO = imagen.GetBytes();

                }
                else
                {
                    ModelState.AddModelError("foto", "Solo se permite imagenes con formato JPG...");
                    return View(obj);
                }

            }

            db.ACTIVO.Add(obj);
            db.SaveChanges();  
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            ACTIVO activo = db.ACTIVO.Find(id);
            ViewBag.IDE_CAT = new SelectList(db.CATEGORIA, "IDE_CAT", "DES_CAT", activo.IDE_CAT);
            ViewBag.IDE_MAR = new SelectList(db.MARCAS, "IDE_MAR", "DES_MAR", activo.IDE_MAR);

            return View(activo);
        }
        [HttpPost]
        public ActionResult Edit(ACTIVO obj)
        {
            ACTIVO _persona = new ACTIVO();

            HttpPostedFileBase archivo = Request.Files[0];
            if (archivo.ContentLength == 0)
            {
                _persona = db.ACTIVO.Find(obj.IDE_ACT);
                obj.IMG_PRO = _persona.IMG_PRO;

            }
            else
            {
                if (archivo.FileName.EndsWith(".jpg"))
                {
                    WebImage imagen = new WebImage(archivo.InputStream);
                    obj.IMG_PRO = imagen.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("foto", "Solo se permite imagenes con formato JPG...");
                    return View(db.TRABAJADOR.Find(obj.IDE_ACT));
                }
            }
            WebImage image = new WebImage(archivo.InputStream);
            obj.IMG_PRO = image.GetBytes();

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
            ACTIVO activo = db.ACTIVO.Find(id);

            return View(activo);
        }

        public ActionResult ActivosSolicitud()
        {
            return View(db.ACTIVO.ToList());
        }
    }
}