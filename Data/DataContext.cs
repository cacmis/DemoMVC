using Microsoft.EntityFrameworkCore;
namespace DemoMVC.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Models.Producto> Productos { get; set; }
        public DbSet<Models.Proveedor> Proveedores { get; set; }
        public DbSet<Models.Categoria> Categorias { get; set; }

    }
}