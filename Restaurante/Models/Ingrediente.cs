using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public double CantidadDisponible { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int DetallePlato { get; set; }
        public required DetallePlato DetallePlatos { get; set; }
    }
}
