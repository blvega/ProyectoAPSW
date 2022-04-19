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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.confirma = TempData["confirma"] as string;

            ViewBag.user = TempData["user"] as string;

          

            TempData["correo"] = "";
            ViewBag.correo = TempData["correo"] as string;



            try
            {
                List<CreditosModelo> creditos;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Creditos");
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        creditos = null;
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
                            creditos = JsonConvert.DeserializeObject<List<CreditosModelo>>(mens);
                        }
                        else
                        {
                            creditos = null;
                        }

                    }

                }

                return View(creditos);
            }
            catch (Exception ex)
            {
                throw ex;
            }





           
        }
        

        public ActionResult Creditos(string categoria)
        {

            try
            {
                List<CreditosModelo> creditos;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Creditos/Lista/"+categoria);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        creditos = null;
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
                            creditos = JsonConvert.DeserializeObject<List<CreditosModelo>>(mens);

                            return View("Index", creditos);

                            //ViewData["Cre"] = creditos;

                            //return new RedirectResult(Url.Action("Index") + "#Cal");


                        }
                        else
                        {
                            creditos = null;

                            return View("Index", creditos);
                        }

                    }

                }

                return View("Index", creditos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public ActionResult Creditos2(string nom,string moneda)
        {

            try
            {
                List<CreditosModelo> creditos;
                using (var client = new HttpClient())
                {
                    var task = Task.Run(async () =>
                    {

                        return await client.GetAsync("https://tiusr7pl.cuc-carrera-ti.ac.cr/api/proyecto1/Creditos/" + nom+"/"+moneda);
                    }
                    );
                    HttpResponseMessage message = task.Result;
                    if (message.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                    {
                        creditos = null;
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
                            creditos = JsonConvert.DeserializeObject<List<CreditosModelo>>(mens);

                            return View("Index", creditos);

                            //ViewData["Cre"] = creditos;

                            //return new RedirectResult(Url.Action("Index") + "#Cal");


                        }
                        else
                        {
                            creditos = null;

                            return View("Index", creditos);
                        }

                    }

                }

                return View("Index", creditos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [AuthorizeUser(idOperacion:1)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [AuthorizeUser(idOperacion: 2)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}