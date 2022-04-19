using DataAccess;
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
    public class ConfiguracionController : ApiController
    {

        private BDProyectoAPSWEntities1 db = new BDProyectoAPSWEntities1();

        [Route("api/proyecto1/ConfUsuarios", Name = "GetConfUsuarios")]
        public HttpResponseMessage GetConfUsuarios()
        {
            try
            {


                var cre = (from t in db.Usuarios
                           select new
                           {

                               t.Identificacion,
                               t.Nombre,
                               t.PrimerApellido,
                               t.SegundoApellido,
                               t.Telefono,
                               t.Correo,
                               t.Password,
                               t.idRol



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

        [Route("api/proyecto1/ConfClientes", Name = "GetConfClientes")]
        public HttpResponseMessage GetConfClientes()
        {
            try
            {


                var cre = (from t in db.Clientes
                           select new
                           {

                               t.Identificacion,
                               t.Nombre,
                               t.PrimerApellido,
                               t.SegundoApellido,
                               t.Telefono,
                               t.Correo,
                               t.FechaNacimiento,
                               t.SalarioNeto,
                               t.Endeudamiento,
                               t.Password,
                               t.idRol



                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay clientes disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }
        [Route("api/proyecto1/ConfCreditos", Name = "GetConfCreditos")]
        public HttpResponseMessage GetConfCreditos()
        {
            try
            {


                var cre = (from t in db.Creditos
                           select new
                           {

                               t.NombreCre,
                               t.TasaColones,
                               t.TasaDolares,
                               t.MaximoPlazo,
                               t.MinimoPlazo,
                               t.MinimoMonto,
                               t.MaximoMonto




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

        [Route("api/proyecto1/ConfUsuarios/{id}", Name = "GetConfUsuariosid")]
        public HttpResponseMessage GetConfUsuariosid(string id)
        {
            try
            {


                var cre = (from t in db.Usuarios
                           where t.Identificacion == id
                           select new
                           {

                               t.Identificacion,
                               t.Nombre,
                               t.PrimerApellido,
                               t.SegundoApellido,
                               t.Telefono,
                               t.Correo,
                               t.Password,
                               t.idRol



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

        [Route("api/proyecto1/ConfClientes/{id}", Name = "GetConfClientesid")]
        public HttpResponseMessage GetConfClientesid(string id)
        {
            try
            {


                var cre = (from t in db.Clientes
                           where t.Identificacion == id
                           select new
                           {

                               t.Identificacion,
                               t.Nombre,
                               t.PrimerApellido,
                               t.SegundoApellido,
                               t.Telefono,
                               t.Correo,
                               t.FechaNacimiento,
                               t.SalarioNeto,
                               t.Endeudamiento,
                               t.Password,
                               t.idRol


                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay clientes disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        [Route("api/proyecto1/ConfCreditos/{id}", Name = "GetConfCreditosid")]
        public HttpResponseMessage GetConfCreditosid(string id)
        {
            try
            {


                var cre = (from t in db.Creditos
                           where t.NombreCre == id
                           select new
                           {

                               t.NombreCre,
                               t.TasaColones,
                               t.TasaDolares,
                               t.MaximoPlazo,
                               t.MinimoPlazo,
                               t.MinimoMonto,
                               t.MaximoMonto



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

        [Route("api/proyecto1/ConfUsuarios/nom/{id}", Name = "GetConfUsuariosnom")]
        public HttpResponseMessage GetConfUsuariosnom(string id)
        {
            try
            {


                var cre = (from t in db.Usuarios
                           where t.Nombre == id
                           select new
                           {

                               t.Identificacion,
                               t.Nombre,
                               t.PrimerApellido,
                               t.SegundoApellido,
                               t.Telefono,
                               t.Correo,
                               t.Password,
                               t.idRol



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

        [Route("api/proyecto1/ConfClientes/nom/{id}", Name = "GetConfClientesnom")]
        public HttpResponseMessage GetConfClientesnom(string id)
        {
            try
            {


                var cre = (from t in db.Clientes
                           where t.Nombre == id
                           select new
                           {

                               t.Identificacion,
                               t.Nombre,
                               t.PrimerApellido,
                               t.SegundoApellido,
                               t.Telefono,
                               t.Correo,
                               t.FechaNacimiento,
                               t.SalarioNeto,
                               t.Endeudamiento,
                               t.Password,
                               t.idRol


                           }).ToList();

                if (cre.Count > 0)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, cre);
                }
                else
                {

                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay clientes disponibles");
                }

            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }




        }

        [Route("api/proyecto1/ConfUsuarios/MostrarRoles/{id}", Name = "GetRoles")]
        public HttpResponseMessage GetRoles(string id)
        {
            try
            {
                int id2 = Int32.Parse(id);

                var cre = (from t in db.Roles
                           where t.idRol == id2
                           select new
                           {
                               t.idRol,
                               t.Nombre




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

        [Route("api/proyecto1/confUsuarios/post", Name = "PostUsuarios")]
        public HttpResponseMessage PostUsuarios(Usuarios usuario)
        {

            try
            {

                if (usuario.Identificacion.Length <= 0 || usuario.Nombre.Length <= 0 || usuario.PrimerApellido.Length <= 0 || usuario.SegundoApellido.Length <= 0 || usuario.Telefono.Length <= 0 || usuario.Correo.Length <= 0 || usuario.Password.Length <= 0 ||
                    usuario.idRol < 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Error...");
                }
                else
                {
                    string contra = usuario.Password;
                    usuario.Password = GetSHA256(usuario.Password);
                    db.Usuarios.Add(usuario);

                    db.SaveChanges();

                    string nom = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;

                    EnviarCorreo2(usuario.Correo, contra, nom, usuario.Identificacion);


                    return Request.CreateResponse(HttpStatusCode.Created, usuario);

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/confClientes/post", Name = "PostClientes")]
        public HttpResponseMessage PostClientes(Clientes cli)
        {

            try
            {

                if (cli.Identificacion.Length <= 0 || cli.FechaNacimiento == null || cli.Nombre.Length <= 0 || cli.PrimerApellido.Length <= 0 || cli.SegundoApellido.Length <= 0 || cli.Telefono.Length <= 0 || cli.Correo.Length <= 0 || cli.Password.Length <= 0 ||
                    cli.idRol < 0 || cli.SalarioNeto <= 0 || cli.Endeudamiento <= 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Error...");
                }
                else if (!ValidarString(cli.Nombre) || !ValidarString(cli.PrimerApellido) || !ValidarString(cli.SegundoApellido))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");

                }
                else
                {
                    string contra = cli.Password;
                    cli.Password = GetSHA256(cli.Password);
                    db.Clientes.Add(cli);

                    db.SaveChanges();

                    string nom = cli.Nombre + " " + cli.PrimerApellido + " " + cli.SegundoApellido;

                    EnviarCorreo3(cli.Correo, contra, nom, cli.Identificacion);

                    return Request.CreateResponse(HttpStatusCode.Created, cli);

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/confCreditos/post", Name = "PostCreditos")]
        public HttpResponseMessage PostCreditos(Creditos credito)
        {

            try
            {

                if (credito.NombreCre.Length <= 0 || credito.TasaColones <= 0 || credito.TasaDolares <= 0 || credito.MinimoMonto <= 0 || credito.MaximoMonto <= 0 || credito.MaximoPlazo <= 0 ||
                    credito.MinimoPlazo < 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Error...");
                }
                else if (!ValidarString(credito.NombreCre))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");

                }
                else
                {


                    db.Creditos.Add(credito);

                    db.SaveChanges();


                    return Request.CreateResponse(HttpStatusCode.Created, credito);

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/confUsuarios/put/{id}", Name = "PutUsuarios")]
        public HttpResponseMessage PutUsuarios(string id, Usuarios user)
        {

            try
            {

                Usuarios gru = db.Usuarios.FirstOrDefault(e => e.Identificacion == id);

                var cur2 = (from t in db.Usuarios
                            where t.Identificacion == id
                            select new
                            {
                                t.Identificacion,
                                t.Nombre,
                                t.PrimerApellido,
                                t.SegundoApellido,
                                t.Telefono,
                                t.Correo,
                                t.Password,
                                t.idRol



                            });


                if (user.Nombre.Length <= 0 || user.PrimerApellido.Length <= 0 || user.SegundoApellido.Length <= 0 || user.Telefono.Length <= 0 || user.Correo.Length <= 0 || user.Password.Length <= 0 ||
                    user.idRol < 0)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");
                }
                else if (!ValidarString(user.Nombre) || !ValidarString(user.PrimerApellido) || !ValidarString(user.SegundoApellido))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");

                }
                else if (gru == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "el usuario con la identificación " + id + " no existe");

                }
                else
                {
                    gru.Nombre = user.Nombre;
                    gru.PrimerApellido = user.PrimerApellido;
                    gru.SegundoApellido = user.SegundoApellido;
                    gru.Telefono = user.Telefono;
                    gru.Correo = user.Correo;
                    gru.Password = GetSHA256(user.Password);
                    gru.idRol = user.idRol;


                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, cur2);
                }

            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/confClientes/put/{id}", Name = "PutClientes")]
        public HttpResponseMessage PutClientes(string id, Clientes cli)
        {

            try
            {

                Clientes gru = db.Clientes.FirstOrDefault(e => e.Identificacion == id);

                var cur2 = (from t in db.Clientes
                            where t.Identificacion == id
                            select new
                            {
                                t.Identificacion,
                                t.Nombre,
                                t.PrimerApellido,
                                t.SegundoApellido,
                                t.Telefono,
                                t.Correo,
                                t.Password,
                                t.idRol



                            });


                if (cli.Identificacion.Length <= 0 || cli.Nombre.Length <= 0 || cli.PrimerApellido.Length <= 0 || cli.SegundoApellido.Length <= 0 || cli.Telefono.Length <= 0 || cli.Correo.Length <= 0 || cli.Password.Length <= 0 ||
                    cli.idRol < 0 || cli.SalarioNeto <= 0 || cli.Endeudamiento <= 0)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");
                }
                else if (!ValidarString(cli.Nombre) || !ValidarString(cli.PrimerApellido) || !ValidarString(cli.SegundoApellido))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");

                }
                else if (gru == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "el cliente con la identificación " + id + " no existe");

                }
                else
                {
                    gru.Nombre = cli.Nombre;
                    gru.PrimerApellido = cli.PrimerApellido;
                    gru.SegundoApellido = cli.SegundoApellido;
                    gru.Telefono = cli.Telefono;
                    gru.Correo = cli.Correo;
                    gru.Password = GetSHA256(cli.Password);
                    gru.idRol = cli.idRol;
                    gru.Endeudamiento = cli.Endeudamiento;
                    gru.SalarioNeto = cli.SalarioNeto;
                    gru.FechaNacimiento = cli.FechaNacimiento;


                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, cur2);
                }

            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/confCreditos/put/{id}", Name = "PutCreditos")]
        public HttpResponseMessage PutCreditos(string id, Creditos credito)
        {

            try
            {

                Creditos gru = db.Creditos.FirstOrDefault(e => e.NombreCre == id);

                var cur2 = (from t in db.Creditos
                            where t.NombreCre == id
                            select new
                            {

                                t.NombreCre,
                                t.TasaColones,
                                t.TasaDolares,
                                t.MaximoPlazo,
                                t.MinimoPlazo,
                                t.MinimoMonto,
                                t.MaximoMonto



                            });


                if (credito.NombreCre.Length <= 0 || credito.TasaColones <= 0 || credito.TasaDolares <= 0 || credito.MinimoMonto <= 0 || credito.MaximoMonto <= 0 || credito.MaximoPlazo <= 0 ||
                    credito.MinimoPlazo < 0)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");
                }
                else if (!ValidarString(credito.NombreCre))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");

                }

                else if (gru == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El credito " + id + " no existe");

                }
                else
                {
                    gru.TasaColones = credito.TasaColones;
                    gru.TasaDolares = credito.TasaDolares;
                    gru.MaximoMonto = credito.MaximoMonto;
                    gru.MinimoMonto = credito.MinimoMonto;
                    gru.MaximoPlazo = credito.MaximoPlazo;
                    gru.MinimoPlazo = credito.MinimoPlazo;
                    gru.Categoria = credito.Categoria;



                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, cur2);
                }

            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/confUsuarios/enviarContra/{id}", Name = "EnvioContra")]
        public HttpResponseMessage EnvioContra(string id, LoginModelo usuario)
        {

            try
            {

                var cur2 = (from t in db.Clientes
                            where t.Identificacion == id && t.Correo == usuario.Correo
                            select new
                            {

                                t.Password


                            }).ToList();

                Clientes cli = db.Clientes.FirstOrDefault(e => e.Identificacion == id);

                if (usuario.Identificacion.Length <= 0 || usuario.Correo.Length <= 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Error...");
                }
                else if (cur2.Count < 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error...");
                }
                else
                {

                    //string contra = GetSHA256(cli.Password);
                    string contra = cli.Password;
                    string correo = cli.Correo;
                    string nombre = cli.Nombre + " " + cli.PrimerApellido + " " + cli.SegundoApellido;

                    EnviarCorreo(correo, contra, nombre);

                    return Request.CreateResponse(HttpStatusCode.OK, cur2);

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/confUsuarios/enviarContra2/{id}", Name = "EnvioContra2")]
        public HttpResponseMessage EnvioContra2(string id, LoginModelo usuario)
        {

            try
            {

                Clientes gru = db.Clientes.FirstOrDefault(e => e.Identificacion == id);

                var cur2 = (from t in db.Clientes
                            where t.Identificacion == id && t.Correo == usuario.Correo
                            select new
                            {

                                t.Identificacion,
                                t.Nombre,
                                t.PrimerApellido,
                                t.SegundoApellido,
                                t.Telefono,
                                t.Correo,
                                t.Password,
                                t.idRol



                            });


                if (usuario.Identificacion.Length <= 0 || usuario.Correo.Length <= 0)
                {

                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");
                }


                else if (gru == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El cliente " + id + " no existe");

                }
                else
                {

                    string contra = GenerarContra();

                    string contra2 = GetSHA256(contra);

                    gru.Password = contra2;




                    db.SaveChanges();

                    string correo = gru.Correo;
                    string nombre = gru.Nombre + " " + gru.PrimerApellido + " " + gru.SegundoApellido;

                    EnviarCorreo(correo, contra, nombre);

                    return Request.CreateResponse(HttpStatusCode.OK, cur2);
                }

            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }
        public void EnviarCorreo(string email, string contra, string nombre)
        {
            try
            {



                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sbdbankcr@gmail.com");
                correo.To.Add(email);
                correo.Subject = "Solicitud de información personal";
                correo.Body = "Estimado cliente: " + "\n\r" + "Sr(a). " + nombre + "\n\r" + "Por este medio se le indica una contraseña para acceder al sistema " +
                     "\n\r" + "Contraseña: " + contra + "\n\r"


                + "\n\r" + "Recordarle que puede restablecer la información personal ingresando en el sistema. "
                + "\n\r" + "\n\r" + "Cualquier consulta estamos para servirle.";



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

        public void EnviarCorreo2(string email, string contra, string nombre, string id)
        {
            try
            {



                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sbdbankcr@gmail.com");
                correo.To.Add(email);
                correo.Subject = "Credenciales de acceso";
                correo.Body = "Estimado colaborador: " + "\n\r" + "Sr(a). " + nombre + "\n\r" + "Por este medio se le brinda el acceso a su usuario " +
                     "\n\r" + "Contraseña: " + contra + "\n\r"
                     + "Identificacion: " + contra + "\n\r"


                + "\n\r" + "\n\r" + "Cualquier consulta estamos para servirle.";



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
        public void EnviarCorreo3(string email, string contra, string nombre, string id)
        {
            try
            {



                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sbdbankcr@gmail.com");
                correo.To.Add(email);
                correo.Subject = "Credenciales de acceso";
                correo.Body = "Estimado cliente: " + "\n\r" + "Sr(a). " + nombre + "\n\r" + "Por este medio se le brinda el acceso a su usuario " +
                     "\n\r" + "Contraseña: " + contra + "\n\r"
                     + "Identificacion: " + contra + "\n\r"


                + "\n\r" + "\n\r" + "Cualquier consulta estamos para servirle.";



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

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
