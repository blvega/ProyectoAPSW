using DataAccess;
using ProyectoAPSW1._2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoAPSW1._2.Controllers
{
    public class TendenciasController : ApiController
    {

        private BDProyectoAPSWEntities1 db = new BDProyectoAPSWEntities1();

        [Route("api/proyecto1/tendencias/clic", Name = "PostClic")]
        public HttpResponseMessage PostClic(TendenciasModelo clics)
        {

            try
            {

                if (clics.NombreCre == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error...");
                }
                else
                {

                    db.Clics.Add(new Clics()
                    {
                        NombreCre = clics.NombreCre,
                        FechaIndicador = DateTime.Now,
                        NumClics = 1

                    });

                    db.SaveChanges();


                    return Request.CreateResponse(HttpStatusCode.OK, clics);

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/tendencias/posicionamiento", Name = "PostPosicionamiento")]
        public HttpResponseMessage PostPosicionamiento(TendenciasModelo posi)
        {

            try
            {

                if (posi.NombreCre == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error...");
                }
                else
                {

                    db.Posicionamiento.Add(new Posicionamiento()
                    {
                        NombreCre = posi.NombreCre,
                        FechaIndicador = DateTime.Now,
                        NumPosicionamiento = 1

                    });

                    db.SaveChanges();


                    return Request.CreateResponse(HttpStatusCode.OK, posi);

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/tendencias/sinRegistro", Name = "PostCantidadInvitado")]
        public HttpResponseMessage PostCantidadInvitado(TendenciasModelo invitado)
        {

            try
            {

                if (invitado.NombreCre == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error...");
                }
                else
                {

                    db.SinRegistro.Add(new SinRegistro()
                    {
                        NombreCre = invitado.NombreCre,
                        FechaIndicador = DateTime.Now,
                        NumUsuarios = 1

                    });

                    db.SaveChanges();


                    return Request.CreateResponse(HttpStatusCode.OK, invitado);

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/tendencias/sinFormalizar", Name = "PostSinFormalizar")]
        public HttpResponseMessage PostSinFormalizar(TendenciasModelo cliente)
        {

            try
            {

                if (cliente.NombreCre == null || cliente.Identificacion == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error...");
                }
                else
                {

                    db.SinFormalizar.Add(new SinFormalizar()
                    {
                        NombreCre = cliente.NombreCre,
                        Identificacion = cliente.Identificacion,
                        FechaIndicador = DateTime.Now


                    });

                    db.SaveChanges();


                    return Request.CreateResponse(HttpStatusCode.OK, cliente);

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        //[Route("api/proyecto1/tendencias/clics/grafico/{fecha}/{fecha1}", Name = "getClic")]
        //public HttpResponseMessage getClic(string fecha)
        //{

        //    try
        //    {

        //        if (fecha == null )
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error...");
        //        }
        //        else
        //        {
        //            DateTime fecha1 = DateTime.Parse(fecha);



        //            var clics = (from t in db.Clics
        //                         where t.FechaIndicador == fecha1
        //                         group t by new { t.FechaIndicador, t.NombreCre } into clic
        //                         select new
        //                         {
        //                             clic.Key.NombreCre,
        //                             Count = clic.Count()


        //                         });

        //            if (clics != null)
        //            {
        //                return Request.CreateResponse(HttpStatusCode.OK, clics);
        //            }
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Fechas no encontradas");

        //        }
        //    }


        //    catch (Exception ex)
        //    {

        //        return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        //    }


        //}

        [Route("api/proyecto1/tendencias/clics/grafico")]
        [HttpPost]
        public HttpResponseMessage getClic1([FromBody] fechaDTO fecha)
        {

            try
            {

                if (fecha == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error...");
                }
                else
                {
                    DateTime fecha1 = DateTime.Parse(fecha.Fecha);
                    DateTime fecha2 = DateTime.Parse(fecha.Fecha1);


                    var clics = (from t in db.Clics
                                 where t.FechaIndicador >= fecha1 && t.FechaIndicador <= fecha2
                                 group t by new { t.NombreCre } into clic
                                 select new
                                 {
                                     clic.Key.NombreCre,
                                     Count = clic.Count()



                                 });

                    if (clics != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, clics);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Fechas no encontradas");

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/tendencias/posicionamiento/grafico")]
        [HttpPost]
        public HttpResponseMessage getClicPosi([FromBody] fechaDTO fecha)
        {

            try
            {

                if (fecha == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error...");
                }
                else
                {
                    DateTime fecha1 = DateTime.Parse(fecha.Fecha);
                    DateTime fecha2 = DateTime.Parse(fecha.Fecha1);


                    var clics = (from t in db.Posicionamiento
                                 where t.FechaIndicador >= fecha1 && t.FechaIndicador <= fecha2

                                 group t by new { t.NombreCre } into clic
                                 select new
                                 {
                                     clic.Key.NombreCre,
                                     Count = clic.Count()










                                 });

                    if (clics != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, clics);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay segundos guardados");

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }


        [Route("api/proyecto1/tendencias/sinregistro/grafico")]
        [HttpPost]
        public HttpResponseMessage getSinRegistro([FromBody] fechaDTO fecha)
        {

            try
            {

                if (fecha == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error...");
                }
                else
                {
                    DateTime fecha1 = DateTime.Parse(fecha.Fecha);
                    DateTime fecha2 = DateTime.Parse(fecha.Fecha1);


                    var clics = (from t in db.SinRegistro
                                 where t.FechaIndicador >= fecha1 && t.FechaIndicador <= fecha2

                                 group t by new { t.NombreCre } into clic
                                 select new
                                 {
                                     clic.Key.NombreCre,
                                     Count = clic.Count()


                                 });

                    if (clics != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, clics);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay segundos guardados");

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/tendencias/sinformalizar/lista")]
        [HttpPost]
        public HttpResponseMessage getSinFormalizar([FromBody] fechaDTO fecha)
        {

            try
            {

                if (fecha == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error...");
                }
                else
                {
                    DateTime fecha1 = DateTime.Parse(fecha.Fecha);
                    DateTime fecha2 = DateTime.Parse(fecha.Fecha1);


                    var clics = (from t in db.SinFormalizar join c in db.Clientes on t.Identificacion equals c.Identificacion
                                 where t.FechaIndicador >= fecha1 && t.FechaIndicador <= fecha2

                                 select new
                                 {
                                     t.Identificacion,
                                     c.Nombre,
                                     c.PrimerApellido,
                                     c.SegundoApellido,
                                     c.Correo,
                                     t.NombreCre,
                                     t.FechaIndicador

                                 });

                    if (clics != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, clics);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay segundos guardados");

                }
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/tendencias/clics/global", Name = "getClicGlobal")]
        public HttpResponseMessage getClicGlobal()
        {

            try
            {

                
                 


                    var clics = (from t in db.Clics
                                 group t by new { t.NombreCre } into clic
                                 select new
                                 {
                                     clic.Key.NombreCre,
                                     Count = clic.Count()


                                 });

                    if (clics != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, clics);
                    }
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay registro de clics");

                
            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/tendencias/posicionamiento/global", Name = "getPosiGlobal")]
        public HttpResponseMessage getPosiGlobal()
        {

            try
            {





                var pos = (from t in db.Posicionamiento
                             group t by new { t.NombreCre } into posi
                             select new
                             {
                                 posi.Key.NombreCre,
                                 Count = posi.Count()


                             });

                if (pos != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, pos);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay registro de posicionamiento");


            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/tendencias/sinregistro/global", Name = "getSinRegistroGlobal")]
        public HttpResponseMessage getSinRegistroGlobal()
        {

            try
            {





                var regi = (from t in db.SinRegistro
                             group t by new { t.NombreCre } into sin
                             select new
                             {
                                 sin.Key.NombreCre,
                                 Count = sin.Count()


                             });

                if (regi != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, regi);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay registro de sin registro");


            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

        [Route("api/proyecto1/tendencias/sinformalizar/global", Name = "getSinFormalizaroGlobal")]
        public HttpResponseMessage getSinFormalizaroGlobal()
        {

            try
            {





                var formalizar = (from t in db.SinFormalizar
                             group t by new { t.NombreCre } into form
                             select new
                             {
                                 form.Key.NombreCre,
                                 Count = form.Count()


                             });

                if (formalizar != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, formalizar);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay registro de posicionamiento");


            }


            catch (Exception ex)
            {

                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }


        }

    }
}
