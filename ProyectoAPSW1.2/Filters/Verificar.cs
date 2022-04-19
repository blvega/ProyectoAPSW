using ProyectoAPSW1._2.Controllers;
using ProyectoAPSW1._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAPSW1._2.Filters
{
    public class Verificar : ActionFilterAttribute
    {
       

        
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //try
            //{
            //    base.OnActionExecuted(filterContext);




            //    string user = (string)HttpContext.Current.Session.Contents["Usuario"];

            //    if (user == null)
            //    {
            //        if (filterContext.Controller is AccesoController == false)
            //        {
            //            filterContext.HttpContext.Response.Redirect("~/Views/Shared/_Layout.cshtml");
            //        }
            //    }

            //}
            //catch
            //{
            //    filterContext.HttpContext.Response.Redirect("~/Views/Shared/_Layout.cshtml");

            //}
        }
    }
}