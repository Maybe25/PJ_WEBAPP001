using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PJ_WEBAPP001.Utils
{
    public class SessionPersister
    {
        static string UsuarioSesionVar = "NombreUsuario";
        static string UserIdSessionVar = "UserIdSession";
        static string UserProfileVar = "UserProfile";
        static string UserRolProfile = "UserRolProfile";

        public static string NombreUsuario
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var SessionVar = HttpContext.Current.Session[UsuarioSesionVar];
                if (SessionVar != null)
                    return SessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[UsuarioSesionVar] = value;
            }
        }
        public static int UsuarioId
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return 0;
                }
                var sessionVar = HttpContext.Current.Session[UserIdSessionVar];
                if (sessionVar != null)
                {
                    return (int)sessionVar;
                }
                return 0;
            }
            set
            {
                HttpContext.Current.Session[UserIdSessionVar] = value;
            }
        }
        public static int UserRol
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return 0;
                }
                var sessionVar = HttpContext.Current.Session[UserRolProfile];
                if (sessionVar != null)
                {
                    return (int)sessionVar;
                }
                return 0;
            }
            set
            {
                HttpContext.Current.Session[UserRolProfile] = value;
            }
        }
        public static string PerfilUsuario
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var SessionVar = HttpContext.Current.Session[UserProfileVar];
                if (SessionVar != null)
                    return SessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[UserProfileVar] = value;
            }
        }
    }
}
