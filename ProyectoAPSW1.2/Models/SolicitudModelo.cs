using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAPSW1._2.Models
{
    public class SolicitudModelo
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

        //Cliente

        //[Required]
        public string Nombre { get; set; }

        //[Required]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        //[Required]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        //[Phone]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        //[EmailAddress]
        public string Correo { get; set; }

      
        public string Password { get; set; }


        //[Required]
        [Display(Name = "Salario Neto")]
        public decimal SalarioNeto { get; set; }

        //[Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Nacimiento")]
        public System.DateTime FechaNacimiento { get; set; }


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