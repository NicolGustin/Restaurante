using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Data
{
    public class InventarioContext
    {
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<DetallePlato> DetallesPlato { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }

    }
}
