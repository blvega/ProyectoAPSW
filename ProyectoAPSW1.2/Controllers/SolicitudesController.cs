using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace ProyectoAPSW1._2.Controllers
{
    public class SolicitudesController : ApiController
    {

        private BDProyectoAPSWEntities1 db = new BDProyectoAPSWEntities1();

        [Route("api/proyecto1/solicitudes", Name = "getSolicitudes")]
        public HttpResponseMessage getSolicitudes()
        {

            try
            {


                var soli = (from t in db.Solicitudes where t.Estado=="Pendiente"


                            select new
                            {
                                t.idSolicitud,
                                t.Fecha,
                                t.Identificacion,
                                t.Monto,
                                t.NombreCre,
                                t.Estado,
                                t.Responsable



                            }).ToList();

                    if (soli.Count >0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, soli);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Estudiante con la identificacion no encontrado");

                
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/solicitudes/aprobadas", Name = "getSolicitudesApro")]
        public HttpResponseMessage getSolicitudesApro()
        {

            try
            {


                var soli = (from t in db.Solicitudes
                            where t.Estado == "Aprobado"


                            select new
                            {
                                t.idSolicitud,
                                t.Fecha,
                                t.Identificacion,
                                t.Monto,
                                t.NombreCre,
                                t.Estado,
                                t.Responsable,
                                t.Comentario



                            }).ToList();

                if (soli.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, soli);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay solicitudes aprobadas");


            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/solicitudes/denegadas", Name = "getSolicitudesDen")]
        public HttpResponseMessage getSolicitudesDen()
        {

            try
            {


                var soli = (from t in db.Solicitudes
                            where t.Estado == "Denegado"


                            select new
                            {
                                t.idSolicitud,
                                t.Fecha,
                                t.Identificacion,
                                t.Monto,
                                t.NombreCre,
                                t.Estado,
                                t.Responsable,
                                t.Comentario



                            }).ToList();

                if (soli.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, soli);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay solicitudes aprobadas");


            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/solicitudes/{id}", Name = "getSolicitudesId")]
        public HttpResponseMessage getSolicitudesId(string id)
        {

            try
            {
                int idSoli =Int32.Parse(id);

                var soli = (from t in db.Solicitudes
                            where t.idSolicitud ==idSoli


                            select new
                            {
                                t.idSolicitud,
                                t.Fecha,
                                t.Identificacion,
                                t.Monto,
                                t.NombreCre,
                                t.Estado,
                              



                            }).ToList();

                if (soli.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, soli);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Solicitud no encontrada");


            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/analistas", Name = "getAnalistas")]
        public HttpResponseMessage getAnalistas()
        {

            try
            {
               

                var analista = (from t in db.Usuarios where t.idRol==2
                            
                            select new
                            {
                                t.Nombre,
                                t.PrimerApellido,
                                t.SegundoApellido
                               

                            }).ToList();

                if (analista.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, analista);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "analista no encontrada");


            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }


        [Route("api/proyecto1/analistas/{id}", Name = "PutSoliAnalista")]
        public HttpResponseMessage PutSoliAnalista(string id, Solicitudes soli)
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

                var analista = (from t in db.Solicitudes
                                where t.Responsable == soli.Responsable && t.Estado=="Pendiente"
                                select new
                                {
                                    t.Responsable
                  

                                }).ToList();

                string ids = soli.Responsable;


                String[] ids2 = ids.Split(' ');

                string nom = ids2[0];
                string ap1 = ids2[1];
                string ap2 = ids2[2];

                var analista2 = (from t in db.Usuarios
                                where t.Nombre == nom && t.PrimerApellido == ap1 && t.SegundoApellido == ap2
                                select new
                                {
                                    t.Correo,

                                }).ToList();



                string correo = analista2[0].ToString();

                correo = correo.Replace("{", "").Replace("}", "");

                String[] correo2 = correo.Split('=');

                string email = correo2[1];




                if (sol == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "");

                }
                else if (analista.Count>=5)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "El analista escogido no puede tener mas de 5 solicitudes asignadas");
                }
                else
                {
                    sol.Responsable = soli.Responsable;


            
                    db.SaveChanges();

                    EnviarCorreo(email, soli.Responsable, id2, soli.Identificacion, soli.Fecha);

                    return Request.CreateResponse(HttpStatusCode.OK, sol2);
                }

            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        public void EnviarCorreo(string email, string nombre, int id2, string id, DateTime fecha)
        {
            try
            {



                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sbdbankcr@gmail.com");
                correo.To.Add(email);
                correo.Subject = "Asignación solicitud de crédito #" + id2;
                correo.Body = "Estimado analista de crédito: " + "\n\r" + "Sr(a). " + nombre + "\n\r" +
                    "Por este medio se le asigna la solicitud detallada acontinuación" +"\n\r" +
                    "ID Solicitud: " + id2 + "\n\r" +
                    "Identificación del cliente: " + id + "\n\r" +
                    "Fecha: " + fecha + "\n\r" +
                    "\n\r" + "\n\r" + "Esta información para su debido estudio para aprobar o no dicha solicitud";



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
