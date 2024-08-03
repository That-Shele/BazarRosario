using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarLib.Models.ApiModels
{
    public class Usuarios
    {
        public int UsuId { get; set; }
        public string? NombreUsu { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
