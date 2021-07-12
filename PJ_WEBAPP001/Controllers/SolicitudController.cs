using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PJ_WEBAPP001.Models;

namespace PJ_WEBAPP001.Controllers
{
    public class SolicitudController : Controller
    {
        BD_ActivoFijosEntities bd = new BD_ActivoFijosEntities();
        private int getPosition(int id)
        {
            List<ActivosItem> compras = (List<ActivosItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Activo.IDE_ACT == id)
                    return i;
            }
            return -1;
        }

        [HttpGet]
        public ActionResult AgregarActivoSolicitud()
        {
            ViewBag.IDE_TRABA = new SelectList(bd.TRABAJADOR,"IDE_TRA","NOM_TRA");
            return View();
        }

        [HttpPost]
        public JsonResult AgregarActivoSolicitud(int id, int cantidad)
        {
            if (Session["carrito"] == null)
            {
                List<ActivosItem> compras = new List<ActivosItem>();
                compras.Add(new ActivosItem(bd.ACTIVO.Find(id), cantidad));
                Session["carrito"] = compras;
            }
            else
            {
                List<ActivosItem> compras = (List<ActivosItem>)Session["carrito"];
                int IndexProducto = getPosition(id);
                if (IndexProducto == -1)
                    compras.Add(new ActivosItem(bd.ACTIVO.Find(id), cantidad));
                else
                    compras[IndexProducto].Cantidad += cantidad;
                Session["carrito"] = compras;
            }
            return Json(new { response = true }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            ViewBag.IDE_TRABA = new SelectList(bd.TRABAJADOR, "IDE_TRA", "NOM_TRA");
            List<ActivosItem> compras = (List<ActivosItem>)Session["carrito"];
            compras.RemoveAt(getPosition(id));
            return View("AgregarActivoSolicitud");
        }
        public ActionResult FinalizarSolicitud(String trabajador = null)
        {
            if (trabajador == null) { trabajador = ""; }
            List<ActivosItem> compras = (List<ActivosItem>)Session["carrito"];
            if (compras != null && compras.Count > 0)
            {
                SOLICITUD boleta = new SOLICITUD();
                ACTIVO prod = new ACTIVO();

                boleta.FEC_SOL = DateTime.Now;
                boleta.IDE_TRA = int.Parse(trabajador);
                boleta.EST_SOL = "Generado";



                boleta.DETALLESOLICITUD = (from activo in compras
                                        select new DETALLESOLICITUD
                                        {
                                            IDE_ACT = activo.Activo.IDE_ACT,
                                            CAN_ART = activo.Cantidad

                                        }).ToList();


                bd.SOLICITUD.Add(boleta);
                bd.SaveChanges();
                Session["carrito"] = new List<ActivosItem>();
            }
            return View();
        }
        public ActionResult Solicitudes()
        {
            return View(bd.SOLICITUD.ToList());
        }
    }
}