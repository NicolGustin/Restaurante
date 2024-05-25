using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Data
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<DetallePlato> DetallePlatos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

    }
}
