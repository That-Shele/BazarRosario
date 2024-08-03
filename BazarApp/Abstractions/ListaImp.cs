using BazarLib.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarApp.Abstractions
{
    public class ListaImp : ILista
    {
        public List<Lista> Lista { get; set; } = new List<Lista>();
    }
}
