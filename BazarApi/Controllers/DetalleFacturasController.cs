using BazarApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BazarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetalleFacturasController : ControllerBase
    {
        public ApplicationDbContext Context { get; set; }
        public DetalleFacturasController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        // GET: api/<DetalleFacturasController>
        [HttpGet]
        public IEnumerable<FacturasDetalle> GetDetalleFacturas()
        {
            return this.Context.FACTURAS_DETALLE.ToList();
        }

        // GET api/<DetalleFacturasController>/5
        [HttpGet]
        public FacturasDetalle GetDetalleFacturaById(int id)
        {
            return (FacturasDetalle)this.Context.FACTURAS_DETALLE.Where(detfac => detfac.CodFac == id);
        }

        // POST api/<DetalleFacturasController>
        [HttpPost]
        public void AddDetalleFactura([FromBody] FacturasDetalle detalle)
        {
            this.Context.FACTURAS_DETALLE.Add(detalle);
            this.Context.SaveChanges();
        }

        
    }
}
