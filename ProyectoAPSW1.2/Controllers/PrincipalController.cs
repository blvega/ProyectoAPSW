using Newtonsoft.Json;
using ProyectoAPSW1._2.Filters;
using ProyectoAPSW1._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAPSW1._2.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal

        [AuthorizeUser(idOperacion: 5)]
        public ActionResult Principal()
        {

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            TempData["mssg"] = Session["Nombre"];
            ViewBag.mssg = TempData["mssg"] as string;
            return View();
        }

        [AuthorizeUser(idOperacion: 3)]
        public ActionResult Principal2()
        {

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            TempData["mssg"] = Session["Nombre"];
            ViewBag.mssg = TempData["mssg"] as string;
            return View();
        }

        [AuthorizeUser(idOperacion: 4)]
        public ActionResult Principal3()
        {
            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            TempData["mssg"] = Session["Nombre"];
            ViewBag.mssg = TempData["mssg"] as string;
            return View();
        }



        [AuthorizeUser(idOperacion: 15)]
        public ActionResult Tendencias()
        {
            TempData["mssg3"] = Session["Nombre"];
            ViewBag.mssg3 = TempData["mssg3"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            return View();
        }

        public ActionResult Personales()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;


            return View();
        }

        public ActionResult Pymes()
        {
            return View();
        }


        public ActionResult Vivienda()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;


            return View();
        }

        [HttpPost]
        public ActionResult Vivienda(CreditosCorreo cre)
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;




            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CreditosCorreo>("proyecto1/Creditos/post", cre);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi



                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        CreditosModelo creditos = JsonConvert.DeserializeObject<CreditosModelo>(mens);

                        EnviarCorreo(cre.Correo, creditos.NombreCre, creditos.MaximoMonto, creditos.MinimoMonto, creditos.MinimoPlazo, creditos.MaximoPlazo, creditos.TasaColones, creditos.TasaDolares.ToString());

                        TempData["correo"] = "¡Envió de información exitoso!";
                        ViewBag.correo = TempData["correo"] as string;
                    }
                    else
                    {
                        return View();
                    }
                }



                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }



        public ActionResult Vehiculo()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;


            return View();
        }

        [HttpPost]
        public ActionResult Vehiculo(CreditosCorreo cre)
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;




            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CreditosCorreo>("proyecto1/Creditos/post", cre);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi



                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        CreditosModelo creditos = JsonConvert.DeserializeObject<CreditosModelo>(mens);

                        EnviarCorreo(cre.Correo, creditos.NombreCre, creditos.MaximoMonto, creditos.MinimoMonto, creditos.MinimoPlazo, creditos.MaximoPlazo, creditos.TasaColones, creditos.TasaDolares.ToString());

                        TempData["correo"] = "¡Envió de información exitoso!";
                        ViewBag.correo = TempData["correo"] as string;
                    }
                    else
                    {
                        return View();
                    }
                }



                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public ActionResult Viajes()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;


            return View();
        }

        [HttpPost]
        public ActionResult Viajes(CreditosCorreo cre)
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;




            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CreditosCorreo>("proyecto1/Creditos/post", cre);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi



                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        CreditosModelo creditos = JsonConvert.DeserializeObject<CreditosModelo>(mens);

                        EnviarCorreo(cre.Correo, creditos.NombreCre, creditos.MaximoMonto, creditos.MinimoMonto, creditos.MinimoPlazo, creditos.MaximoPlazo, creditos.TasaColones, creditos.TasaDolares.ToString());

                        TempData["correo"] = "¡Envió de información exitoso!";
                        ViewBag.correo = TempData["correo"] as string;
                    }
                    else
                    {
                        return View();
                    }
                }



                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public ActionResult Estudios()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;


            return View();
        }

        [HttpPost]
        public ActionResult Estudios(CreditosCorreo cre)
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;




            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CreditosCorreo>("proyecto1/Creditos/post", cre);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi



                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        CreditosModelo creditos = JsonConvert.DeserializeObject<CreditosModelo>(mens);

                        EnviarCorreo(cre.Correo, creditos.NombreCre, creditos.MaximoMonto, creditos.MinimoMonto, creditos.MinimoPlazo, creditos.MaximoPlazo, creditos.TasaColones, creditos.TasaDolares.ToString());

                        TempData["correo"] = "¡Envió de información exitoso!";
                        ViewBag.correo = TempData["correo"] as string;
                    }
                    else
                    {
                        return View();
                    }
                }



                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public ActionResult Salud()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;


            return View();
        }

        [HttpPost]
        public ActionResult Salud(CreditosCorreo cre)
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;




            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CreditosCorreo>("proyecto1/Creditos/post", cre);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi



                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        CreditosModelo creditos = JsonConvert.DeserializeObject<CreditosModelo>(mens);

                        EnviarCorreo(cre.Correo, creditos.NombreCre, creditos.MaximoMonto, creditos.MinimoMonto, creditos.MinimoPlazo, creditos.MaximoPlazo, creditos.TasaColones, creditos.TasaDolares.ToString());

                        TempData["correo"] = "¡Envió de información exitoso!";
                        ViewBag.correo = TempData["correo"] as string;
                    }
                    else
                    {
                        return View();
                    }
                }



                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public ActionResult Unificacion()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;


            return View();
        }


        [HttpPost]
        public ActionResult Unificacion(CreditosCorreo cre)
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;




            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CreditosCorreo>("proyecto1/Creditos/post", cre);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi



                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        CreditosModelo creditos = JsonConvert.DeserializeObject<CreditosModelo>(mens);

                        EnviarCorreo(cre.Correo, creditos.NombreCre, creditos.MaximoMonto, creditos.MinimoMonto, creditos.MinimoPlazo, creditos.MaximoPlazo, creditos.TasaColones, creditos.TasaDolares.ToString());

                        TempData["correo"] = "¡Envió de información exitoso!";
                        ViewBag.correo = TempData["correo"] as string;
                    }
                    else
                    {
                        return View();
                    }
                }



                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }



        public ActionResult CompraMaquinaria()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;


            return View();
        }

        [HttpPost]
        public ActionResult CompraMaquinaria(CreditosCorreo cre)
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;




            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CreditosCorreo>("proyecto1/Creditos/post", cre);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi



                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        CreditosModelo creditos = JsonConvert.DeserializeObject<CreditosModelo>(mens);

                        EnviarCorreo(cre.Correo, creditos.NombreCre, creditos.MaximoMonto, creditos.MinimoMonto, creditos.MinimoPlazo, creditos.MaximoPlazo, creditos.TasaColones, creditos.TasaDolares.ToString());

                        TempData["correo"] = "¡Envió de información exitoso!";
                        ViewBag.correo = TempData["correo"] as string;
                    }
                    else
                    {
                        return View();
                    }
                }



                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public ActionResult MejoraInstalaciones()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;


            return View();
        }

        [HttpPost]
        public ActionResult MejoraInstalaciones(CreditosCorreo cre)
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;




            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CreditosCorreo>("proyecto1/Creditos/post", cre);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi



                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        CreditosModelo creditos = JsonConvert.DeserializeObject<CreditosModelo>(mens);

                        EnviarCorreo(cre.Correo, creditos.NombreCre, creditos.MaximoMonto, creditos.MinimoMonto, creditos.MinimoPlazo, creditos.MaximoPlazo, creditos.TasaColones, creditos.TasaDolares.ToString());

                        TempData["correo"] = "¡Envió de información exitoso!";
                        ViewBag.correo = TempData["correo"] as string;
                    }
                    else
                    {
                        return View();
                    }
                }



                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }



        public ActionResult CapitalTrabajo()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;


            return View();
        }

        [HttpPost]
        public ActionResult CapitalTrabajo(CreditosCorreo cre)
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

          
          

            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CreditosCorreo>("proyecto1/Creditos/post", cre);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi
                       


                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        CreditosModelo creditos = JsonConvert.DeserializeObject<CreditosModelo>(mens);

                        EnviarCorreo(cre.Correo, creditos.NombreCre, creditos.MaximoMonto, creditos.MinimoMonto, creditos.MinimoPlazo, creditos.MaximoPlazo, creditos.TasaColones, creditos.TasaDolares.ToString());

                        TempData["correo"] = "¡Envió de información exitoso!";
                        ViewBag.correo = TempData["correo"] as string;
                    }
                    else
                    {
                        return View();
                    }
                }



                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public ActionResult VehiculoTrabajo()
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;


            return View();
        }

        [HttpPost]
        public ActionResult VehiculoTrabajo(CreditosCorreo cre)
        {
            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;




            try
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<CreditosCorreo>("proyecto1/Creditos/post", cre);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi



                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        CreditosModelo creditos = JsonConvert.DeserializeObject<CreditosModelo>(mens);

                        EnviarCorreo(cre.Correo, creditos.NombreCre, creditos.MaximoMonto, creditos.MinimoMonto, creditos.MinimoPlazo, creditos.MaximoPlazo, creditos.TasaColones, creditos.TasaDolares.ToString());

                        TempData["correo"] = "¡Envió de información exitoso!";
                        ViewBag.correo = TempData["correo"] as string;
                    }
                    else
                    {
                        return View();
                    }
                }



                return View();


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }
        [AuthorizeUser(idOperacion: 12)]
        public ActionResult SolicitudCliente()
        {
            TempData["mssg"] = Session["Nombre"];
            ViewBag.mssg = TempData["mssg"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            string id = Session["Identificacion"].ToString();

            List<TramiteModelo> tramite;
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {

                    return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ClientesSolicitud/"+id);
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

        [AuthorizeUser(idOperacion: 12)]
        public ActionResult AdministracionCliente()
        {

            TempData["mssg"] = Session["Nombre"];
            ViewBag.mssg = TempData["mssg"] as string;

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"];

            string id = Session["Identificacion"].ToString(); 


            List<ClientesModelo> tramite;
            using (var client = new HttpClient())
            {
                var task = Task.Run(async () =>
                {

                    return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/ConfClientes/"+id);
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

            public void EnviarCorreo(string email,  string NombreCre, decimal MontoMaximo, decimal MontoMinimo, int minimoplazo, int maximoplazo ,decimal TasaInteresC, string TasaInteresD)
        {
            try
            {



                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("sbdbankcr@gmail.com");
                correo.To.Add(email);
                correo.Subject = "Solicitud de información del tipo de crédito " + NombreCre;
                correo.Body = "Estimado usuario: " + "\n\r"+"Por este medio se le adjunta la información solicitada. " 
                 


                + "\n\r" + "Tipo de crédito: " + NombreCre
                
                  + "\n\r" + "Monto mínimo: " + MontoMinimo
                   + "\n\r" + "Monto máximo: " + MontoMaximo
                   + "\n\r" + "Plazo mínimo: " + minimoplazo +" meses"
                    + "\n\r" + "Plazo máximo: " + maximoplazo +" meses"
                     + "\n\r" + "Tasa de interés en colones: " + TasaInteresC+"%"
                      + "\n\r" + "Tasa de interés en dólares: " + TasaInteresD + "%"

                + "\n\r" + "\n\r" + "Cualquier consulta estamos para servirle."+
                 "\n\r" + "SBD Bank";


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