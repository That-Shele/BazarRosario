using BazarApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BazarAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public ApplicationDbContext Context { get; set; }
        public UsuariosController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Usuarios> GetUsuarios()
        {
            return this.Context.USUARIOS.ToList();
        }

        // GET api/<UsuariosController>/5
        [HttpGet]
        public Usuarios ValidateUsuario(string email)
        {
            return this.Context.USUARIOS.First(usu => usu.Email == email);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public void AddUsuario([FromBody] Usuarios usuario)
        {
            this.Context.USUARIOS.Add(usuario);
            this.Context.SaveChanges();
        }

        
    }
}
