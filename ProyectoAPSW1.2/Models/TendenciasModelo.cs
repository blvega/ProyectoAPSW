using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPSW1._2.Models
{
    public class TendenciasModelo
    {

        public string NombreCre { get; set; }
        public string Identificacion { get; set; }
        public int NumClics { get; set; }
        public System.DateTime FechaIndicador { get; set; }

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