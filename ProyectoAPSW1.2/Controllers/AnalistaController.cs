using DataAccess;
using Newtonsoft.Json;
using ProyectoAPSW1._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace ProyectoAPSW1._2.Controllers
{
    public class AnalistaController : ApiController
    {

        private BDProyectoAPSWEntities1 db = new BDProyectoAPSWEntities1();

        [Route("api/proyecto1/Solicitudes/Analista/{id}", Name = "GetSoliAnalista1")]
        public HttpResponseMessage GetSoliAnalista1(string id)
        {

            try
            {

                var soli = (from t in db.Solicitudes join c in db.Clientes on t.Identificacion equals c.Identificacion
                           where t.Responsable == id && t.Estado=="Pendiente"
                           select new
                           {
                               t.idSolicitud,
                               t.Identificacion,
                               c.Endeudamiento,
                               t.Fecha,
                               t.NombreCre,
                               t.Monto,
                               t.TasaInteres,
                               t.Estado,
                               t.Responsable,
                               t.Comentario

                           }).ToList();
                //EstudianteCorreo est = db.EstudianteCorreo.Where(x => x.Identificacion == id).SingleOrDefault();

                if (soli.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, soli);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Solicitud con el analista ingresado no encontrado");
            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/Solicitudes/Analista1/{id}", Name = "GetSoliAnalista2")]
        public HttpResponseMessage GetSoliAnalista2(string id)
        {

            try
            {
                int id2 = Int32.Parse(id);

                var soli = (from t in db.Solicitudes
                            join c in db.Clientes on t.Identificacion equals c.Identificacion
                            where t.idSolicitud == id2
                            select new
                            {
                                t.idSolicitud,
                                t.Identificacion,
                                c.Endeudamiento,
                                t.Fecha,
                                t.NombreCre,
                                t.Monto,
                                t.TasaInteres,
                                t.Estado,
                                t.Responsable,
                                t.Comentario

                            }).ToList();
                //EstudianteCorreo est = db.EstudianteCorreo.Where(x => x.Identificacion == id).SingleOrDefault();

                if (soli.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, soli);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Solicitud con el analista ingresado no encontrado");
            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }


        [Route("api/proyecto1/analista/Estado/{id}", Name = "PutAnalistaEstado")]
        public HttpResponseMessage PutAnalistaEstado(string id, Solicitudes soli)
        {

            try
            {
                int id2 = Int32.Parse(id);

                Solicitudes sol = db.Solicitudes.FirstOrDefault(e => e.idSolicitud == id2);

                var sol2 = (from t in db.Solicitudes
                            where t.idSolicitud == id2
                            select new
                            {
                                t.idSolicitud,
                                t.Fecha,
                                t.Identificacion,
                                t.Monto,
                                t.NombreCre,
                                t.Estado,
                                t.Responsable



                            });


                string ids = soli.Responsable;

               
                String[] ids2 = ids.Split(' ');

                string nom = ids2[0];
                string ap1 = ids2[1];
                string ap2 = ids2[2];

                var cliente = (from t in db.Clientes
                                where t.Identificacion==soli.Identificacion
                                select new
                                {
                                    t.Correo,
                                    t.Nombre,
                                    t.PrimerApellido,
                                    t.SegundoApellido
                              
                                }).ToList();



                string correo = cliente[0].ToString();

                correo = correo.Replace("{", "").Replace("}", "");

                String[] correo2 = correo.Split('=',',');

         

                string email = correo2[1];

                


                string nomcli = correo2[3] + correo2[5] + correo2[7];



                if (sol == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "");

                }
               
                else
                {


                    sol.Estado = soli.Estado;
                    sol.Comentario = soli.Comentario;



                    db.SaveChanges();

                    EnviarCorreo(email, soli.Responsable, id2, soli.Identificacion, soli.Fecha,soli.NombreCre,soli.Monto,soli.TasaInteres, soli.Estado,soli.Comentario, nomcli);



                    return Request.CreateResponse(HttpStatusCode.OK, sol2);
                }

            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/Solicitudes/Aprobadas/Nombre/{id}", Name = "GetSolicitudesApro2")]
        public HttpResponseMessage GetSolicitudesApro2(string id)
        {
            try
            {


                var cre = (from t in db.Solicitudes
                           where t.NombreCre == id where t.Estado=="Aprobado"
                           select new
                           {

                               t.idSolicitud,
                               t.Identificacion,
                               t.Fecha,
                               t.Monto,
                               t.NombreCre,
                               t.TasaInteres,
                               t.Estado,
                               t.Responsable,
                               t.Comentario



                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay usuarios disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        [Route("api/proyecto1/Solicitudes/Aprobadas/Identificacion/{id}", Name = "GetSolicitudesApro3")]
        public HttpResponseMessage GetSolicitudesApro3(string id)
        {
            try
            {


                var cre = (from t in db.Solicitudes
                           where t.Identificacion == id
                           where t.Estado == "Aprobado"
                           select new
                           {

                               t.idSolicitud,
                               t.Identificacion,
                               t.Fecha,
                               t.Monto,
                               t.NombreCre,
                               t.TasaInteres,
                               t.Estado,
                               t.Responsable,
                               t.Comentario



                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay usuarios disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        [Route("api/proyecto1/Solicitudes/Aprobadas/idSoli/{id}", Name = "GetSolicitudesApro4")]
        public HttpResponseMessage GetSolicitudesApro4(string id)
        {
            try
            {
                int ids = Int32.Parse(id);

                var cre = (from t in db.Solicitudes
                           where t.idSolicitud == ids
                           where t.Estado == "Aprobado"
                           select new
                           {

                               t.idSolicitud,
                               t.Identificacion,
                               t.Fecha,
                               t.Monto,
                               t.NombreCre,
                               t.TasaInteres,
                               t.Estado,
                               t.Responsable,
                               t.Comentario



                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay usuarios disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        //denegadas
        [Route("api/proyecto1/Solicitudes/Denegado/Nombre/{id}", Name = "GetSolicitudesDene2")]
        public HttpResponseMessage GetSolicitudesDene2(string id)
        {
            try
            {


                var cre = (from t in db.Solicitudes
                           where t.NombreCre == id
                           where t.Estado == "Denegado"
                           select new
                           {

                               t.idSolicitud,
                               t.Identificacion,
                               t.Fecha,
                               t.Monto,
                               t.NombreCre,
                               t.TasaInteres,
                               t.Estado,
                               t.Responsable,
                               t.Comentario



                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay usuarios disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        [Route("api/proyecto1/Solicitudes/Denegado/Identificacion/{id}", Name = "GetSolicitudesDene3")]
        public HttpResponseMessage GetSolicitudesDene3(string id)
        {
            try
            {


                var cre = (from t in db.Solicitudes
                           where t.Identificacion == id
                           where t.Estado == "Denegado"
                           select new
                           {

                               t.idSolicitud,
                               t.Identificacion,
                               t.Fecha,
                               t.Monto,
                               t.NombreCre,
                               t.TasaInteres,
                               t.Estado,
                               t.Responsable,
                               t.Comentario



                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay usuarios disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        [Route("api/proyecto1/Solicitudes/Denegado/idSoli/{id}", Name = "GetSolicitudesDene4")]
        public HttpResponseMessage GetSolicitudesDene4(string id)
        {
            try
            {
                int ids = Int32.Parse(id);

                var cre = (from t in db.Solicitudes
                           where t.idSolicitud == ids
                           where t.Estado == "Denegado"
                           select new
                           {

                               t.idSolicitud,
                               t.Identificacion,
                               t.Fecha,
                               t.Monto,
                               t.NombreCre,
                               t.TasaInteres,
                               t.Estado,
                               t.Responsable,
                               t.Comentario



                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay usuarios disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }
        //pendiente


        [Route("api/proyecto1/Solicitudes/Pendiente1/Nombre/{id}", Name = "GetSolicitudesPendiente2")]
        public HttpResponseMessage GetSolicitudesPendiente2(string id)
        {
            try
            {


                var cre = (from t in db.Solicitudes
                           where t.NombreCre == id
                           where t.Estado == "Pendiente"
                           select new
                           {

                               t.idSolicitud,
                               t.Identificacion,
                               t.Fecha,
                               t.Monto,
                               t.NombreCre,
                               t.TasaInteres,
                               t.Estado,
                               t.Responsable,
                               t.Comentario



                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay usuarios disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        [Route("api/proyecto1/Solicitudes/Pendiente3/Identificacion/{id}", Name = "GetSolicitudesPendiente3")]
        public HttpResponseMessage GetSolicitudesPendiente3(string id)
        {
            try
            {


                var cre = (from t in db.Solicitudes
                           where t.Identificacion == id
                           where t.Estado == "Pendiente"
                           select new
                           {

                               t.idSolicitud,
                               t.Identificacion,
                               t.Fecha,
                               t.Monto,
                               t.NombreCre,
                               t.TasaInteres,
                               t.Estado,
                               t.Responsable,
                               t.Comentario



                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay usuarios disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        [Route("api/proyecto1/Solicitudes/Pendiente4/idSoli/{id}", Name = "GetSolicitudesPendiente4")]
        public HttpResponseMessage GetSolicitudesPendiente4(string id)
        {
            try
            {
                int ids = Int32.Parse(id);

                var cre = (from t in db.Solicitudes
                           where t.idSolicitud == ids
                           where t.Estado == "Pendiente"
                           select new
                           {

                               t.idSolicitud,
                               t.Identificacion,
                               t.Fecha,
                               t.Monto,
                               t.NombreCre,
                               t.TasaInteres,
                               t.Estado,
                               t.Responsable,
                               t.Comentario



                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay usuarios disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }



        public void EnviarCorreo(string email, string nombre, int id2, string id, DateTime fecha, string NombreCre, decimal Monto, decimal TasaInteres, string estado, string comentario, string nomcli)
        {
            try
            {



                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sbdbankcr@gmail.com");
                correo.To.Add(email);
                correo.Subject = "Resultado de la solicitud #" + id2;
                correo.Body = "Estimado cliente: " + "\n\r" + "Sr(a). " + nomcli + "\n\r" + "Por este medio se le notifica el resultado de la solicitud de crédito realizada " +
                     "\n\r" + "El estado de la solicitud realizada es: "+estado+"." + "\n\r" 
                   

                +"\n\r" + "Analista de crédito encargado: " + nombre
                +"\n\r"+"\n\r" + "Cualquier consulta estamos para servirle.";



                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                string co = "sbdbankcr@gmail.com";
                string cont = "SbD123456";
                smtp.Credentials = new System.Net.NetworkCredential(co, cont);
                smtp.Send(correo);

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }

        }

    }
}
