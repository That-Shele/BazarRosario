using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BazarApi.Models
{
    [PrimaryKey(nameof(ProduId))]
    public class Productos
    {
        
        public int ProduId { get; set; }
        [Required]
        [MaxLength(18)]
        public string? Categoria { get; set; }
        [Required]
        [MaxLength(50)]
        public string? TipoProdu {  get; set; }
        [Required]
        [MaxLength(250)]
        public string? NombreProdu { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 999999.99)]
        public decimal Precio { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public byte[]? ImgProdu { get; set; }
        [Required]
        public bool IsOferta { get; set; }
    }
}
