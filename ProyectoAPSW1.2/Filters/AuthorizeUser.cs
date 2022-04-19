using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAPSW1._2.Filters
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private BDProyectoAPSWEntities1 db = new BDProyectoAPSWEntities1();
        private int idOperacion;
        private string usuario;
        private int rol;

        public AuthorizeUser(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreOperacion = "";
            String nombreModulo = "";

            try { 
            
            usuario = (string)HttpContext.Current.Session.Contents["Usuario"];
                var rol2 = HttpContext.Current.Session.Contents["Rol"];



                if (rol2 == null)
                {
                    rol = 4;
                }
                else
                {
                    rol = (int)HttpContext.Current.Session.Contents["Rol"];
                }



             
                var lstMisOperaciones = from m in db.Rol_operacion
                                        where m.idRol == rol
                                            && m.idOperacion == idOperacion
                                        select m;

                if (lstMisOperaciones.ToList().Count() == 0)
                {
                    var oOperacion = db.Operaciones.Find(idOperacion);
                    int? idModulo = oOperacion.idModulo;
                    nombreOperacion = getNombreDeOperacion(idOperacion);
                    nombreModulo = getNombreDelModulo(idModulo);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=");
                }


            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=");
            }
            //base.OnAuthorization(filterContext);
        }


        public string getNombreDeOperacion(int idOperacion)
        {
            var ope = from op in db.Operaciones
                      where op.idOperaciones == idOperacion
                      select op.NombreOperacion;
            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }

        public string getNombreDelModulo(int? idModulo)
        {
            var modulo = from m in db.Modulo
                         where m.idModulo == idModulo
                         select m.Nombre;
            String nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }

    }
}