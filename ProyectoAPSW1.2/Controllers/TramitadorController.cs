using Newtonsoft.Json;
using ProyectoAPSW1._2.Filters;
using ProyectoAPSW1._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAPSW1._2.Controllers
{
    public class TramitadorController : Controller
    {
        // GET: Tramitador

        [AuthorizeUser(idOperacion: 14)]
        public ActionResult Solicitudes()
        {
            TempData["mssg2"] = Session["Nombre"];
            ViewBag.mssg2 = TempData["mssg2"] as string;
            return View();
        }


        [AuthorizeUser(idOperacion: 15)]
        public ActionResult Clic()
        {

            TempData["mssg4"] = Session["Nombre"];
            ViewBag.mssg4 = TempData["mssg4"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            try
            {
                List<TendenciasG> tramite;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/clics/global");
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        tramite = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        if (!string.IsNullOrEmpty(mens))
                        {
                            tramite = JsonConvert.DeserializeObject<List<TendenciasG>>(mens);
                        }
                        else
                        {
                            tramite = null;

                        }

                    }

                }

                return View(tramite);
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        [AuthorizeUser(idOperacion: 15)]
        public ActionResult Posicionamiento()
        {
            TempData["mssg4"] = Session["Nombre"];
            ViewBag.mssg4 = TempData["mssg4"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            try
            {
                List<TendenciasG> tramite;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/posicionamiento/global");
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        tramite = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        if (!string.IsNullOrEmpty(mens))
                        {
                            tramite = JsonConvert.DeserializeObject<List<TendenciasG>>(mens);
                        }
                        else
                        {
                            tramite = null;

                        }

                    }

                }

                return View(tramite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [AuthorizeUser(idOperacion: 15)]
        public ActionResult SinRegistro()


        {

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            TempData["mssg4"] = Session["Nombre"];
            ViewBag.mssg4 = TempData["mssg4"] as string;

            try
            {
                List<TendenciasG> tramite;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/sinregistro/global");
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        tramite = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        if (!string.IsNullOrEmpty(mens))
                        {
                            tramite = JsonConvert.DeserializeObject<List<TendenciasG>>(mens);
                        }
                        else
                        {
                            tramite = null;

                        }

                    }

                }

                return View(tramite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [AuthorizeUser(idOperacion: 15)]
        public ActionResult SinFormalizar()
        {
            TempData["mssg4"] = Session["Nombre"];
            ViewBag.mssg4 = TempData["mssg4"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            try
            {
                List<TendenciasG> tramite;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/tendencias/sinformalizar/global");
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        tramite = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        if (!string.IsNullOrEmpty(mens))
                        {
                            tramite = JsonConvert.DeserializeObject<List<TendenciasG>>(mens);
                        }
                        else
                        {
                            tramite = null;

                        }

                    }

                }

                return View(tramite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //Solicitudes
        [AuthorizeUser(idOperacion: 14)]
        public ActionResult MenuSolicitudes()
        {
            TempData["mssg4"] = Session["Nombre"];
            ViewBag.mssg4 = TempData["mssg4"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            return View();
        }
        [AuthorizeUser(idOperacion: 14)]
        public ActionResult Tramite()
        {
            TempData["mssg4"] = Session["Nombre"];
            ViewBag.mssg4 = TempData["mssg4"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];




            try
            {
                List<TramiteModelo> tramite;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/solicitudes");
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        tramite = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        if (!string.IsNullOrEmpty(mens))
                        {
                            tramite = JsonConvert.DeserializeObject<List<TramiteModelo>>(mens);
                        }
                        else
                        {
                            tramite = null;
                        }

                    }

                }

                return View(tramite);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        [AuthorizeUser(idOperacion: 14)]
        public ActionResult Aprobadas()
        {
            TempData["mssg4"] = Session["Nombre"];
            ViewBag.mssg4 = TempData["mssg4"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];




            try
            {
                List<TramiteModelo> tramite;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/solicitudes/aprobadas");
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        tramite = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        if (!string.IsNullOrEmpty(mens))
                        {
                            tramite = JsonConvert.DeserializeObject<List<TramiteModelo>>(mens);
                        }
                        else
                        {
                            tramite = null;
                        }

                    }

                }

                return View(tramite);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public ActionResult Print()
        {
            return new Rotativa.PartialViewAsPdf("Aprobadas");
        }

        [AuthorizeUser(idOperacion: 14)]
        public ActionResult Denegadas()
        {
            TempData["mssg4"] = Session["Nombre"];
            ViewBag.mssg4 = TempData["mssg4"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];


            try
            {
                List<TramiteModelo> tramite;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/solicitudes/denegadas");
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        tramite = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        if (!string.IsNullOrEmpty(mens))
                        {
                            tramite = JsonConvert.DeserializeObject<List<TramiteModelo>>(mens);
                        }
                        else
                        {
                            tramite = null;
                        }

                    }

                }

                return View(tramite);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        [HttpPut]
        public ActionResult Tramite(string ids)
        {

            try
            {
                List<TramiteModelo> tramite;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/solicitudes");
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        tramite = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        if (!string.IsNullOrEmpty(mens))
                        {
                            tramite = JsonConvert.DeserializeObject<List<TramiteModelo>>(mens);
                        }
                        else
                        {
                            tramite = null;
                        }

                    }

                }

                return View(tramite);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [AuthorizeUser(idOperacion: 13)]
        public ActionResult SoliAnalista()
        {


            try
            {

                TempData["mssg"] = Session["Nombre"];
                ViewBag.mssg = TempData["mssg"] as string;

                TempData["rol"] = Session["rol"];
                ViewBag.rol = TempData["rol"];

                List<TramiteModelo> tramite;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Solicitudes/Analista/" + Session["Nombre"]);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        tramite = null;
                    }
                    else
                    {
                        var task2 = Task<string>.Run(async () =>
                        {
                            return await message.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;
                        if (!string.IsNullOrEmpty(mens))
                        {
                            tramite = JsonConvert.DeserializeObject<List<TramiteModelo>>(mens);
                        }
                        else
                        {
                            tramite = null;
                        }

                    }

                }

                return View(tramite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        public ActionResult TramitadorUsuarios()
        {

            TempData["mssg"] = Session["Nombre"];
            ViewBag.mssg = TempData["mssg"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];
            return View();

        }
        [AuthorizeUser(idOperacion: 16)]
        public ActionResult ConfUsuarios()
        {

            TempData["mssg"] = Session["Nombre"];
            ViewBag.mssg = TempData["mssg"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];



            List<UsuariosModelo> tramite;
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {

                    return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios");
                }
                );
                HttpResponseMessage message = task.Result;
                if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    tramite = null;
                }
                else
                {
                    var task2 = Task<string>.Run(async () =>
                    {
                        return await message.Content.ReadAsStringAsync();
                    });
                    string mens = task2.Result;
                    if (!string.IsNullOrEmpty(mens))
                    {
                        tramite = JsonConvert.DeserializeObject<List<UsuariosModelo>>(mens);
                    }
                    else
                    {
                        tramite = null;
                    }

                }

            }
            return View(tramite);

        }

        [HttpPost]
        public ActionResult ConfUsuarios(UsuarioModelo usuario)
        {

            TempData["mssg"] = Session["Nombre"];
            ViewBag.mssg = TempData["mssg"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];



            List<UsuariosModelo> tramite;
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {

                    return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios");
                }
                );
                HttpResponseMessage message = task.Result;
                if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    tramite = null;
                }
                else
                {
                    var task2 = Task<string>.Run(async () =>
                    {
                        return await message.Content.ReadAsStringAsync();
                    });
                    string mens = task2.Result;
                    if (!string.IsNullOrEmpty(mens))
                    {
                        tramite = JsonConvert.DeserializeObject<List<UsuariosModelo>>(mens);
                    }
                    else
                    {
                        tramite = null;
                    }

                }

            }
            return View(tramite);

        }

        [HttpPost]
        public ActionResult ConfUsuarios(string param, string valor)
        {


            try
            {
                if (param == "1")
                {
                    List<UsuariosModelo> tramite;
                    using (var client = new HttpClient())
                    {
                        var task = Task.Run(async () =>
                        {

                            return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfUsuarios/" + valor);
                        }
                        );
                        HttpResponseMessage message = task.Result;
                        if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                        {
                            tramite = null;
                        }
                        else
                        {
                            var task2 = Task<string>.Run(async () =>
                            {
                                return await message.Content.ReadAsStringAsync();
                            });
                            string mens = task2.Result;
                            if (!string.IsNullOrEmpty(mens))
                            {
                                tramite = JsonConvert.DeserializeObject<List<UsuariosModelo>>(mens);
                            }
                            else
                            {
                                tramite = null;

                            }

                        }

                    }

                    return View(tramite);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [AuthorizeUser(idOperacion: 16)]
        public ActionResult ConfClientes()
        {

            TempData["mssg"] = Session["Nombre"];
            ViewBag.mssg = TempData["mssg"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];



            List<ClientesModelo> tramite;
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {

                    return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfClientes");
                }
                );
                HttpResponseMessage message = task.Result;
                if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    tramite = null;
                }
                else
                {
                    var task2 = Task<string>.Run(async () =>
                    {
                        return await message.Content.ReadAsStringAsync();
                    });
                    string mens = task2.Result;
                    if (!string.IsNullOrEmpty(mens))
                    {
                        tramite = JsonConvert.DeserializeObject<List<ClientesModelo>>(mens);
                    }
                    else
                    {
                        tramite = null;
                    }

                }

            }
            return View(tramite);

        }

        [AuthorizeUser(idOperacion: 16)]
        public ActionResult ConfCreditos()
        {

            TempData["mssg"] = Session["Nombre"];
            ViewBag.mssg = TempData["mssg"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];



            List<CreditosModelo> tramite;
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {

                    return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfCreditos");
                }
                );
                HttpResponseMessage message = task.Result;
                if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    tramite = null;
                }
                else
                {
                    var task2 = Task<string>.Run(async () =>
                    {
                        return await message.Content.ReadAsStringAsync();
                    });
                    string mens = task2.Result;
                    if (!string.IsNullOrEmpty(mens))
                    {
                        tramite = JsonConvert.DeserializeObject<List<CreditosModelo>>(mens);
                    }
                    else
                    {
                        tramite = null;
                    }

                }

            }
            return View(tramite);

        }


    }
}