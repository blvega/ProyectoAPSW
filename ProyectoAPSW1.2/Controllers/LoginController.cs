using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Http;
using DataAccess;
using ProyectoAPSW1._2.Models;

namespace ProyectoAPSW1._2.Controllers
{
    public class LoginController : ApiController
    {
        private BDProyectoAPSWEntities1 db = new BDProyectoAPSWEntities1();

        [Route("api/proyecto1/Login", Name = "Login1")]
        public IHttpActionResult Login1(LoginModelo log)
        {

            string contra = GetSHA256(log.Password);
            var user = (from t in db.Usuarios
                        where t.Identificacion == log.Identificacion && t.Password == contra

                        select new
                        {
                          t.Nombre,
                          t.PrimerApellido,
                          t.SegundoApellido,
                          t.Identificacion,
                          
                            t.Password,
                            t.idRol,

                        }).ToList();

            var clientes = (from t in db.Clientes
                            where t.Identificacion == log.Identificacion && t.Password == contra

                            select new
                            {

                                t.Nombre,
                                t.PrimerApellido,
                                t.SegundoApellido,
                                t.Identificacion,

                                t.Password,
                                t.idRol,
                            }).ToList();


            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }
            else if (log.Identificacion == null || log.Password == null)
            {
                return BadRequest("Not a valid model");
            }
            else if (user.Count > 0 && clientes.Count == 0)
            {
               
                return Ok(user);
            }
            else if (user.Count == 0 && clientes.Count > 0)
            {
                return Ok(clientes);
            }
            else
            {

                return BadRequest();
            }
        }


        [Route("api/proyecto1/cambioContra/put/{id}", Name = "PutContra")]
        public HttpResponseMessage PutContra(string id, LoginModelo log)
        {

            try
            {

                //string contra = GetSHA256(log.Password);
                var user = (from t in db.Usuarios
                            where t.Identificacion == log.Identificacion 

                            select new
                            {
                                t.Nombre,
                                t.PrimerApellido,
                                t.SegundoApellido,
                                t.Identificacion,

                                t.Password,
                                t.idRol,

                            }).ToList();

                var clientes = (from t in db.Clientes
                                where t.Identificacion == log.Identificacion 

                                select new
                                {

                                    t.Nombre,
                                    t.PrimerApellido,
                                    t.SegundoApellido,
                                    t.Identificacion,

                                    t.Password,
                                    t.idRol,
                                }).ToList();


                Usuarios users = db.Usuarios.FirstOrDefault(e => e.Identificacion == id);
                Clientes cli = db.Clientes.FirstOrDefault(e => e.Identificacion == id);



                if (log.Password.Length <= 0 || log.Identificacion.Length <= 0 )
                {

                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");
                }
                //else if (!ValidarString(log.Identificacion))
                //{
                //    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");

                //}
                else if (user.Count > 0 && clientes.Count == 0)
                {

                    //return Ok(user);
                    users.Password = GetSHA256(log.Password);
                


                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
                else if (user.Count == 0 && clientes.Count > 0)
                {
                    //return Ok(clientes);
                    cli.Password = GetSHA256(log.Password);



                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, clientes);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Ningún dato puede estar vacío");
                }

            }
            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
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
    }
}
