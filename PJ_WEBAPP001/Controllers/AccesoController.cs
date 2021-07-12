using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PJ_WEBAPP001.Utils;

namespace PJ_WEBAPP001.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user,string pass)
        {
            try
            {
                using (Models.Sis_UsuariosEntities db = new Models.Sis_UsuariosEntities())
                {
                    var oUser = (from d in db.usuario
                                 where d.nombre == user.Trim() && d.password == pass.Trim()
                                 select d).FirstOrDefault();
                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o clave invalida";
                        return View();
                    }
                    Session["User"] = oUser;
                    SessionPersister.NombreUsuario = oUser.nombre;
                    SessionPersister.UsuarioId = oUser.id;
                    if (oUser.idRol == 1) {SessionPersister.PerfilUsuario = "Administrador"; }
                    if (oUser.idRol == 2) {SessionPersister.PerfilUsuario = "RRHH"; }
                    if (oUser.idRol == 3) {SessionPersister.PerfilUsuario = "Sistemas"; }

                    SessionPersister.UserRol = (int)oUser.idRol;
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ViewBag.Error = "Registro Incorrecto, verificar en llenar todos los campos";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["User"] = null;
            SessionPersister.NombreUsuario = null;
            SessionPersister.UsuarioId = 0;
            SessionPersister.PerfilUsuario = null;
            return RedirectToAction("Login", "Acceso");
            
        }

    }
}