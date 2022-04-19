using DataAccess;
using ProyectoAPSW1._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoAPSW1._2.Controllers
{
    public class PreCalculoController : ApiController
    {
        private BDProyectoAPSWEntities1 db = new BDProyectoAPSWEntities1();

        [Route("api/proyecto1/Creditos", Name = "GetCreditos")]
        public HttpResponseMessage GetCreditos()
        {
            try
            {
           

                var cre = (from t in db.Creditos 
                           select new
                           {
                               
                               t.NombreCre
                               //t.MaximoMonto,
                               //t.MinimoMonto,
                               //t.MaximoPlazo,
                               //t.MinimoPlazo,
                               //t.TasaInteres
                            

                           }).ToList();

                if (cre.Count>0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else { 

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay creditos disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

    [Route("api/proyecto1/Creditos/{nom}/{moneda}", Name = "GetCreditosNom")]
    public HttpResponseMessage GetCreditosNom(string nom, string moneda)
    {
        try
        {
                if (moneda=="Colones") {
                var cre = (from t in db.Creditos where t.NombreCre ==nom
                       select new
                       {
                           t.NombreCre,
                           t.MaximoMonto,
                           t.MinimoMonto,
                           t.MaximoPlazo,
                           t.MinimoPlazo,
                           t.TasaColones


                       }).ToList();

                

                if (cre.Count > 0)
            {

                return Request.CreateResponse(HttpStatusCode.OK, cre);
            }
            else
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay creditos disponibles");
            }
                }
                else
                {
                    var cre = (from t in db.Creditos
                               where t.NombreCre == nom
                               select new
                               {
                                   t.NombreCre,
                                   t.MaximoMonto,
                                   t.MinimoMonto,
                                   t.MaximoPlazo,
                                   t.MinimoPlazo,
                                   t.TasaDolares


                               }).ToList();



                    if (cre.Count > 0)
                    {

                        return Request.CreateResponse(HttpStatusCode.OK, cre);
                    }
                    else
                    {

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay creditos disponibles");
                    }
                }
            }
        catch
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }




    }

        [Route("api/proyecto1/Creditos/{nom}", Name = "GetCreditosNom2")]
        public HttpResponseMessage GetCreditosNom2(string nom)
        {
            try
            {
                
                    var cre = (from t in db.Creditos
                               where t.NombreCre == nom
                               select new
                               {
                                   t.NombreCre,
                                   t.MaximoMonto,
                                   t.MinimoMonto,
                                   t.MaximoPlazo,
                                   t.MinimoPlazo,
                                   t.TasaColones,
                                   t.TasaDolares


                               }).ToList();



                    if (cre.Count > 0)
                    {

                        return Request.CreateResponse(HttpStatusCode.OK, cre);
                    }
                    else
                    {

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay creditos disponibles");
                    }
                
               
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        [HttpPost]
        [Route("api/proyecto1/Creditos/post", Name = "GetCreditosNom3")]
        public IHttpActionResult GetCreditosNom3(CreditosCorreo creditos )
        {


            var cre = (from t in db.Creditos
                       where t.NombreCre == creditos.NombreCre
                       select new
                       {
                           t.NombreCre,
                           t.MaximoMonto,
                           t.MinimoMonto,
                           t.MaximoPlazo,
                           t.MinimoPlazo,
                           t.TasaColones,
                           t.TasaDolares


                       }).ToList();
         
                      


             if (cre !=null)
            {
                return Ok(cre);
            }
            else
            {

                return BadRequest();
            }
        }



        [Route("api/proyecto1/Creditos/Lista/{categoria}", Name = "GetCreditos2")]
public HttpResponseMessage GetCreditos2(string categoria)
{
    try
    {


        var cre = (from t in db.Creditos
                   where t.Categoria == categoria

                   select new
                   {
                       t.NombreCre,


                   }).ToList();

        if (cre.Count > 0)
        {

            return Request.CreateResponse(HttpStatusCode.OK, cre);
        }
        else
        {

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay creditos disponibles");
        }

    }
    catch
    {
        return new HttpResponseMessage(HttpStatusCode.InternalServerError);
    }




}

    }
}