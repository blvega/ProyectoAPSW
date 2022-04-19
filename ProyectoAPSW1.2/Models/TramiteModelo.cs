using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAPSW1._2.Models
{
    public class TramiteModelo
    {

        public int idSolicitud { get; set; }
        //[Required]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }
        public System.DateTime Fecha { get; set; }

        //[Required]
        public decimal Monto { get; set; }

        //[Required]
        [Display(Name = "Nombre Crédito")]
        public string NombreCre { get; set; }

        //[Required]
        [Display(Name = "Tasa de Interés")]
        public decimal TasaInteres { get; set; }
        public string Estado { get; set; }
        public string Responsable { get; set; }

        public decimal Endeudamiento { get; set; }

        public string Comentario { get; set; }


        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        public override string ToString()
        {
            return ToJsonString();
        }
    }
}