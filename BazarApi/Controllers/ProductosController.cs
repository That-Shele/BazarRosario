using BazarApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BazarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        public ApplicationDbContext Context { get; set; }
        public ProductosController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        // GET: api/<ProductosController>
        [HttpGet]
        public IEnumerable<Productos> GetProductos()
        {
            return this.Context.PRODUCTOS.ToList();
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public Productos GetProductoById(int id)
        {
            return this.Context.PRODUCTOS.First(produ => produ.ProduId == id);
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void AddProducto([FromBody] Productos producto)
        {
            this.Context.PRODUCTOS.Add(producto);
            this.Context.SaveChanges();
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public void EditProducto(int id, [FromBody] Productos productoEdit)
        {
            Productos productoAct = this.GetProductoById(id);

            productoAct.NombreProdu = productoEdit.NombreProdu;
            productoAct.TipoProdu = productoEdit.TipoProdu;
            productoAct.Precio = productoEdit.Precio;
            productoAct.Categoria = productoEdit.Categoria;
            productoAct.ImgProdu = productoEdit.ImgProdu;
            productoAct.Stock = productoEdit.Stock;
            productoAct.IsOferta = productoEdit.IsOferta;

            this.Context.SaveChanges();
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public void DeleteProducto(int id)
        {
            Productos productoAct = this.GetProductoById(id);
            this.Context.PRODUCTOS.Remove(productoAct);
            this.Context.SaveChanges();
        }
    }
}
