using BazarApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BazarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        public ApplicationDbContext Context { get; set; }
        public FacturasController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        // GET: api/<FacturasController>
        [HttpGet]
        public IEnumerable<Facturas> GetFacturas()
        {
            return this.Context.FACTURAS.ToList();
        }

        // GET api/<FacturasController>/5
        [HttpGet("{id}")]
        public Facturas GetFacturaById(int id)
        {
            return this.Context.FACTURAS.First(fac => fac.CodFac == id);
        }

        // POST api/<FacturasController>
        [HttpPost]
        public void AddFactura([FromBody] Facturas factura)
        {
            this.Context.FACTURAS.Add(factura);
            this.Context.SaveChanges();
        }

        
    }
}
