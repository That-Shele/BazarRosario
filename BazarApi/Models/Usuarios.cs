using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BazarApi.Models
{
    [PrimaryKey(nameof(UsuId))]
    public class Usuarios
    {
        
        public int UsuId { get; set; }
        [Required]
        [MaxLength(80)]
        public string? NombreUsu { get; set; }
        [Required]
        [MaxLength(90)]
        public string? Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }
        [Required]
        public bool? IsAdmin { get; set; }
    }
}
