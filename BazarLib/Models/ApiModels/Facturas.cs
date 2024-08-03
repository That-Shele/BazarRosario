using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarLib.Models.ApiModels
{
    public class Facturas
    {
        public int CodFac { get; set; }
        public string? NombreUsu { get; set; }
        public decimal Pago { get; set; }
        public DateTime Fecha { get; set; }
    }
}
