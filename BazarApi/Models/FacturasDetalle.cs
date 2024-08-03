using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BazarApi.Models
{
    
    public class FacturasDetalle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CodFac { get; set; }
        [Required]
        [MaxLength(80)]
        public string? NombreUsu { get; set; }
        [Required]
        [MaxLength(250)]
        public string? NombreProdu { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 99999.99)]
        public decimal Pago { get; set; }

    }
}
