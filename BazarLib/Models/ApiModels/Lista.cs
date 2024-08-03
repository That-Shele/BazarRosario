using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarLib.Models.ApiModels
{
    public class Lista
    {
        public int ProduId { get; set; }
        public string? NombreUsu { get; set; }
        public string? NombreProdu { get; set; }
        public int Cantidad { get; set; }
        public decimal Pago { get; set; }
        public decimal Total { get; set; }  
    }
}
