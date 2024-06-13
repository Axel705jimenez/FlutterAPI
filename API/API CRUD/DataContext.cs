using Microsoft.EntityFrameworkCore;

namespace API_CRUD
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
