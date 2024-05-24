namespace Restaurante.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int IngredienteId { get; set; }
        public int ProveedorId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime FechaCompra { get; set; }

        public Ingrediente Ingrediente { get; set; }
        public Proveedor proveedor { get; set; }
    }
}
