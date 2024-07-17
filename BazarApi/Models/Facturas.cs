using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BazarApi.Models
{
    [PrimaryKey(nameof(CodFac))]
    public class Facturas
    {
        public int CodFac {  get; set; }
        [Required]
        [MaxLength(80)]
        public string? NombreUsu {  get; set; }
        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        [Range(0, 99999.99)]
        public decimal Pago { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
    }
}
