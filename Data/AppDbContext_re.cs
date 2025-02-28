using Libreria2.Models;
using Microsoft.EntityFrameworkCore;

namespace Libreria2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Almacen> Almacen { get; set; }

        public DbSet<Ubicacion> Ubicaciones { get; set; }



    }
}
