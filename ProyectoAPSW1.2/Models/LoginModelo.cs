using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAPSW1._2.Models
{
    public class LoginModelo
    {

        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        public string Correo { get; set; }

        [Required]
        public string Identificacion { get; set; }

        [Required]
        public string Password { get; set; }


        public int idRol { get; set; }

       


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