using Newtonsoft.Json;
using ProyectoAPSW1._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;




namespace ProyectoAPSW1._2.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {

            Session["rol"] = "4";

            TempData["rol"] = Session["rol"];
            ViewBag.rol = TempData["rol"] as string;


            Session["Usuario"] = " ";
            Session["Nombre"] = "";

            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginModelo log)
        {
            try
            {
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://tiusr7pl.cuc-carrera-ti.ac.cr/Api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<LoginModelo>("proyecto1/Login", log);
                    postTask.Wait();

                    var result = postTask.Result;


                    if (result.IsSuccessStatusCode)
                    {
                        //cambiar a identi
                        Session["Usuario"] = log.Identificacion;

                        TempData["user"] = Session["Usuario"].ToString();
                        TempData["user2"] = Session["Usuario"].ToString();


                        var task2 = Task<string>.Run(async () =>
                        {
                            return await result.Content.ReadAsStringAsync();
                        });
                        string mens = task2.Result;

                        mens = string.Join("", mens.Split('[', ']'));


                        LoginModelo login = JsonConvert.DeserializeObject<LoginModelo>(mens);

                        int rol = login.idRol;

                        Session["Rol"] = rol;

                        Session["Identificacion"] = login.Identificacion;

                        Session["Nombre"] = login.Nombre +" "+ login.PrimerApellido + " "+ login.SegundoApellido;

                       

                        

                        if (rol == 3) {
                            return RedirectToAction("Principal", "Principal");

                        }else if(rol == 1)
                        {
                            return RedirectToAction("Principal2", "Principal");
                        }else if (rol==2)
                        {
                            return RedirectToAction("Principal3", "Principal");
                        }

                        
                    }
                    else
                    {
                        TempData["errorL"] = "Correo y/o contraseña incorrecto";
                        ViewBag.errorL = TempData["errorL"] as string;
                        //ModelState.AddModelError(string.Empty, "Correo y/o contraseña incorrecto");
                        Session["Usuario"] =null;
                    }
                }

                

                return View(log);


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}