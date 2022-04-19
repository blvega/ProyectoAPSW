using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPSW1._2.Models
{
    public class CreditosCorreo
    {

        public string NombreCre { get; set; }

        public string Correo { get; set; }

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