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

        [HttpGet("{id}")]
        public Usuarios GetUsuarioById(int id)
        {
            return this.Context.USUARIOS.First(usu => usu.UsuId == id);
        }

        [HttpPost]
        public void AddUsuario([FromBody] Usuarios usuario)
        {
            this.Context.USUARIOS.Add(usuario);
            this.Context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void EditUsuario(int id, [FromBody] Usuarios usuarioEdit)
        {
            Usuarios usuarioAct = this.GetUsuarioById(id);

            usuarioAct.NombreUsu = usuarioEdit.NombreUsu;
            usuarioAct.Email = usuarioEdit.Email;
            usuarioAct.Password = usuarioEdit.Password;
            usuarioAct.IsAdmin = usuarioEdit.IsAdmin;
            
            this.Context.SaveChanges();
        }


    }
}
