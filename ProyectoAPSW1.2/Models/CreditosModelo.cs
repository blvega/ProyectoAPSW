using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAPSW1._2.Models
{
    public class CreditosModelo
    {

        public string NombreCre { get; set; }
        public decimal MaximoMonto { get; set; }
        public decimal MinimoMonto { get; set; }
        public int MaximoPlazo { get; set; }
        public int MinimoPlazo { get; set; }
        public decimal TasaColones { get; set; }
        public string Categoria { get; set; }
        public Nullable<decimal> TasaDolares { get; set; }


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