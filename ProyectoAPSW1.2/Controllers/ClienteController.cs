using DataAccess;
using Newtonsoft.Json;
using ProyectoAPSW1._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace ProyectoAPSW1._2.Controllers
{
    public class ClienteController : ApiController
    {
        private BDProyectoAPSWEntities1 db = new BDProyectoAPSWEntities1();

        [Route("api/proyecto1/Clientes/{id}", Name = "GetClienteId")]
        public HttpResponseMessage GetClienteId(string id)
        {

            try
            {

                var cli = (from t in db.Clientes
                              where t.Identificacion == id
                              select new
                              {
                                  t.Nombre,
                                  t.PrimerApellido,
                                  t.SegundoApellido,
                                  t.Telefono,
                                  t.Correo,
                                  t.FechaNacimiento,
                                  t.SalarioNeto

                              }).ToList();
                //EstudianteCorreo est = db.EstudianteCorreo.Where(x => x.Identificacion == id).SingleOrDefault();

                if (cli.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, cli);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cliente con la identificacion " + id + " no encontrado");
            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/Clientes", Name = "PostSolicitud")]
        public HttpResponseMessage PostSolicitud(SolicitudModelo solicitud)
        {



            try
            {
                int estado;



                var cli2 = (from t in db.Clientes
                            where t.Identificacion == solicitud.Identificacion
                            select new
                            {
                                t.Nombre,
                                t.PrimerApellido,
                                t.SegundoApellido,
                                t.Telefono,
                                t.Correo,
                                t.FechaNacimiento,
                                t.SalarioNeto



                            }).ToList();



                Clientes cli = db.Clientes.Where(x => x.Identificacion == solicitud.Identificacion).SingleOrDefault();




                if (cli == null)
                {
                    if (solicitud.Identificacion == null || solicitud.Monto <= 0 || solicitud.NombreCre.Length == 0 || solicitud.TasaInteres <= 0 ||
                    solicitud.Nombre == null || solicitud.PrimerApellido == null || solicitud.SegundoApellido == null
                    || solicitud.Telefono.Length == 0 || solicitud.Correo == null ||
                    solicitud.FechaNacimiento == DateTime.MinValue || solicitud.SalarioNeto <= 0)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Los datos no pueden estar vacios");



                    }
                    else
                    {
                        string contra = GenerarContra();
                        string contra2 = GetSHA256(contra);





                        solicitud.Fecha = DateTime.Now;





                        estado = db.RegistroSolicitud(solicitud.Identificacion, solicitud.Monto, solicitud.NombreCre, solicitud.TasaInteres, solicitud.Nombre,
                        solicitud.PrimerApellido, solicitud.SegundoApellido, solicitud.Telefono, solicitud.Correo,
                        solicitud.FechaNacimiento, solicitud.SalarioNeto, contra2, 3, solicitud.Fecha);




                        var soli = (from t in db.Solicitudes
                                    where t.Identificacion == solicitud.Identificacion && t.Monto == solicitud.Monto
                                    select new
                                    {
                                        t.idSolicitud




                                    }).ToList();



                        string ids = soli[0].ToString();



                        ids = ids.Replace("{", "").Replace("}", "");



                        String[] ids2 = ids.Split('=');




                        solicitud.idSolicitud = Int32.Parse(ids2[1]);





                        EnviarCorreo(solicitud.idSolicitud, solicitud.Correo, contra, solicitud.Nombre, solicitud.PrimerApellido, solicitud.SegundoApellido, solicitud.NombreCre, solicitud.TasaInteres.ToString(), solicitud.Monto.ToString(), solicitud.Identificacion);




                        if (estado == 2)
                        {
                            return Request.CreateResponse(HttpStatusCode.Created, cli2);
                        }



                        else
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Error al ingresar el estudiante.");
                        }
                    }



                }



                else
                {
                    if (solicitud.Identificacion == null || solicitud.Monto <= 0 || solicitud.NombreCre.Length == 0 || solicitud.TasaInteres <= 0 ||
                    solicitud.Nombre == null || solicitud.PrimerApellido == null || solicitud.SegundoApellido == null
                    || solicitud.Telefono.Length == 0 || solicitud.Correo == null ||
                    solicitud.FechaNacimiento == DateTime.MinValue || solicitud.SalarioNeto <= 0)
                    {



                        return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Los datos no pueden estar vacios");
                    }
                    else
                    {



                        //var euTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time");
                        //DateTime euTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, euTimeZone);



                        solicitud.Fecha = DateTime.Now;




                        estado = db.RegistroSolicitud(solicitud.Identificacion, solicitud.Monto, solicitud.NombreCre, solicitud.TasaInteres,
                        null, null, null, null, null, null, null, null, null, solicitud.Fecha);





                        var soli = (from t in db.Solicitudes
                                    where t.Identificacion == solicitud.Identificacion && t.Monto == solicitud.Monto
                                    select new
                                    {
                                        t.idSolicitud




                                    }).ToList();



                        string ids = soli[0].ToString();



                        ids = ids.Replace("{", "").Replace("}", "");



                        String[] ids2 = ids.Split('=');






                        solicitud.idSolicitud = Int32.Parse(ids2[1]);



                        //var analista = (from t in db.Usuarios



                        // select new
                        // {
                        // t.Nombre



                        // }).ToString();



                        //List<AnalistaModelo> Modelo = JsonConvert.DeserializeObject<List<AnalistaModelo>>(analista);




                        //foreach (AnalistaModelo a in Modelo)
                        //{
                        // Console.WriteLine(a.Nombre);
                        //}







                        EnviarCorreoRegistrado(solicitud.idSolicitud, solicitud.Correo, solicitud.Password, solicitud.Nombre, solicitud.PrimerApellido, solicitud.SegundoApellido, solicitud.NombreCre, solicitud.TasaInteres.ToString(), solicitud.Monto.ToString(), solicitud.Identificacion);



                        if (estado == 1)
                        {
                            return Request.CreateResponse(HttpStatusCode.Created, cli2);
                        }



                        else
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Error al ingresar el estudiante.");
                        }
                    }



                }



            }
            catch (Exception ex)
            {



                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        [Route("api/proyecto1/ClientesSolicitud/{id}", Name = "GetClientesSoli")]
        public HttpResponseMessage GetClientesSoli(string id)
        {
            try
            {


                var cre = (from t in db.Solicitudes
                           where t.Identificacion == id
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

        public void Hora()
        {
            
            

        }

        public string GenerarContra()
        {

            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 10;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }
            return contraseniaAleatoria;
        }

        public void EnviarCorreo(int idsoli, string email, string pass, string nom, string ap1, string ap2, string tcredito, string tasa, string monto, string id)
        {
            try
            {

                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sbdbankcr@gmail.com");
                correo.To.Add(email);
                correo.Subject = "Confirmación de solicitud de crédito #"+idsoli;
                correo.Body = "Estimado cliente: " + "\n\r" + "Sr(a). " + nom + " " + ap1 + " " + ap2 + "\n\r" + "Por este medio se le notifica que su solicitud" +
                    " de crédito a sido recibida con éxito." + "\n\r" + "A continuación se detalla el crédito solicitado." + "\n\r" +
                    "ID Solicitud: " + idsoli + "\n\r" +
                    "Tipo crédito: " + tcredito + "\n\r" +
                    "Monto solicitado: " + monto + "\n\r" +
                    //"Plazo: " + plazo + "\n\r" + "" +
                    "Tasa interés: " + tasa + "\n\r" + "\n\r" + "Se le ha asignado una contraseña para acceder a la consulta de la solicitud: " + "\n\r" + "Usuario: " + id + "\n\r" +
                    "Contraseña: " + pass + "\n\r" + "Será un gusto atenderle cualquier consulta.";


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

        public void EnviarCorreoRegistrado(int idsoli, string email, string pass, string nom, string ap1, string ap2, string tcredito, string tasa, string monto, string id)
        {
            try
            {



                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sbdbankcr@gmail.com");
                correo.To.Add(email);
                correo.Subject = "Confirmación de solicitud de crédito #" + idsoli;
                correo.Body = "Estimado cliente: " + "\n\r" + "Sr(a). " + nom + " " + ap1 + " " + ap2 + "\n\r" + "Por este medio se le notifica que su solicitud" +
                    " de crédito a sido recibida con éxito." + "\n\r" + "A continuación se detalla el crédito solicitado." + "\n\r" +
                    "ID Solicitud: " + idsoli + "\n\r" +
                    "Tipo crédito: " + tcredito + "\n\r" +
                    "Monto solicitado: " + monto + "\n\r" + "Tasa interés: " + tasa + "\n\r" + "\n\r" + "Será un gusto atenderle cualquier consulta.";



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
        public bool ValidarString(string st)
        {
            Regex r = new Regex("^[a-zA-Z ]+$");
            if (r.IsMatch(st))
                return true;
            else
                return false;
        }

        public bool ValidarInt(string st)
        {
            Regex r = new Regex("^[0-9]*$");
            if (r.IsMatch(st))
                return true;
            else
                return false;
        }

        public string GetSHA256(string str)
        {
            SHA256 sha = SHA256.Create();

            byte[] stream = sha.ComputeHash(Encoding.Default.GetBytes(str));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < stream.Length; i++)
            {

                sb.Append(stream[i].ToString("x2"));

            }

            return sb.ToString();


        }

        [Route("api/proyecto1/Soli", Name = "GetSoli")]
        public HttpResponseMessage GetSoli(string id)
        {

            try
            {

                var cli = (from t in db.Clientes
                           where t.Identificacion == id
                           select new
                           {
                               t.Nombre,
                               t.PrimerApellido,
                               t.SegundoApellido,
                               t.Telefono,
                               t.Correo,
                               t.FechaNacimiento,
                               t.SalarioNeto

                           }).ToList();
                //EstudianteCorreo est = db.EstudianteCorreo.Where(x => x.Identificacion == id).SingleOrDefault();

                if (cli.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, cli);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Cliente con la identificacion " + id + " no encontrado");
            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }


    }



}
