using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CaptchaMvc.HtmlHelpers;
using Newtonsoft.Json;
using ProyectoAPSW1._2.Models;

namespace ProyectoAPSW1._2.Controllers
{
    public class SolicitudController : Controller
    {
        // GET: Solicitud
        public ActionResult Index()
        {

            //TempData["monto"] = monto;
            //ViewBag.mssg1 = TempData["monto"] as string;

            //TempData["tasa"] = tasa;
            //ViewBag.mssg2 = TempData["tasa"] as string;

            //TempData["nom"] = nomcre;
            //ViewBag.mssg3 = TempData["nom"] as string;

            return View();
        }


        public ActionResult Solicitud(string monto, string tasa, string nomcre)
        {

            ViewBag.usuario2 = TempData["user2"] as string;

            if (monto==null || tasa==null || nomcre == null)
            {
                TempData["monto"] = Session["mont"];
                ViewBag.mssg1 = TempData["monto"] as string;

                TempData["tasa"] = Session["tasa"];
                ViewBag.mssg2 = TempData["tasa"] as string;

                TempData["nom"] = Session["nom"];
                ViewBag.mssg3 = TempData["nom"] as string;

               
            }
            else
            {
                Session["mont"] = monto;
                TempData["monto"] = Session["mont"];
                ViewBag.mssg1 = TempData["monto"] as string;

                Session["tasa"] = tasa;
                TempData["tasa"] = Session["tasa"];
                ViewBag.mssg2 = TempData["tasa"] as string;

                Session["nom"] = nomcre;
                TempData["nom"] = Session["nom"];
                ViewBag.mssg3 = TempData["nom"] as string;

              
            }
           


            return View();
        }

       

        [HttpPost]
        public ActionResult Solicitud(SolicitudModelo solicitud)
        {


            // Code for validating the CAPTCHA  
            if (this.IsCaptchaValid(errorText:""))
            {
                try
                {
                    string json = solicitud.ToJsonString();
                    using (var client = new HttpClient())
                    {
                        var task = Task.Run(async () =>
                        {

                            
                            return await client.PostAsync(
                            "https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Clientes",
                            new StringContent(json, Encoding.UTF8, "application/json")
                        );
                        }
                        );
                        HttpResponseMessage message = task.Result;
                        if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                        {
                            solicitud = null;
                        }
                        else if(message.StatusCode == System.Net.HttpStatusCode.Created)
                        {
                            TempData["confirma"] = "Solicitud realizada con éxito";
                            


                         

                            return RedirectToAction("Index", new RouteValueDictionary(new { controller = "Home" }));
                        }
                        else
                        {

                            TempData["monto"] = Session["mont"];
                            ViewBag.mssg1 = TempData["monto"] as string;

                            TempData["tasa"] = Session["tasa"];
                            ViewBag.mssg2 = TempData["tasa"] as string;

                            TempData["nom"] = Session["nom"];
                            ViewBag.mssg3 = TempData["nom"] as string;

                            ViewBag.usuario = TempData["user"] as string;

                          

                            TempData["confirma2"] = "Error al realizar la solicitud, revise que los datos ingresados estén correctos";
                            ViewBag.confirma2 = TempData["confirma2"] as string;

                            //ModelState.AddModelError(string.Empty, "Error al realizar la solicitud, revise que los datos ingresados estén correctos");


                        }

                    }

                  
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {

                TempData["monto"] = Session["mont"];
                ViewBag.mssg1 = TempData["monto"] as string;

                TempData["tasa"] = Session["tasa"];
                ViewBag.mssg2 = TempData["tasa"] as string;

                TempData["nom"] = Session["nom"];
                ViewBag.mssg3 = TempData["nom"] as string;

                ViewBag.usuario = TempData["user"] as string;

                //ModelState.AddModelError(string.Empty, "Error al realizar la solicitud, medida de seguridad inválida");

                TempData["confirma3"] = "Error al realizar la solicitud, medida de seguridad inválida";
                ViewBag.confirma3 = TempData["confirma3"] as string;
            }


            return View("Solicitud");


        }

        [HttpGet]
        public ActionResult Clienteid(string id)
        {

            try
            {
                List<SolicitudModelo> solicitud;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Clientes/" + id);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        solicitud = null;
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
                            solicitud = JsonConvert.DeserializeObject<List<SolicitudModelo>>(mens);

                            return View("Solicitud", solicitud);

                            //ViewData["Cre"] = creditos;

                            //return new RedirectResult(Url.Action("Index") + "#Cal");


                        }
                        else
                        {
                            solicitud = null;

                            return View("Solicitud", solicitud);
                        }

                    }

                }

                return View("Solicitud", solicitud);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



  


    }


}