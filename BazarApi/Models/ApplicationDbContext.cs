using Microsoft.EntityFrameworkCore;

namespace BazarApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> USUARIOS { get; set; }
        public DbSet<Productos> PRODUCTOS { get; set; }
        public DbSet<Facturas> FACTURAS { get; set; }
        public DbSet<FacturasDetalle> FACTURAS_DETALLE { get; set; }
    }
}
