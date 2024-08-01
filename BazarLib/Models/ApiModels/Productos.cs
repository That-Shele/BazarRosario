using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarLib.Models.ApiModels
{
    public class Productos
    {
        public int ProduId { get; set; }

        public string? Categoria { get; set; }

        public string? TipoProdu { get; set; }

        public string? NombreProdu { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public byte[]? ImgProdu { get; set; }

        public bool IsOferta { get; set; }
    }
}
