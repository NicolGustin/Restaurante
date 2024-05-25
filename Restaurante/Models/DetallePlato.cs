using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class DetallePlato
    {
        [Key]
        public int IdDetalle { get; set; }

        [ForeignKey("Plato")]
        public int IdPlato { get; set; }
        public Plato Plato { get; set; }

        [ForeignKey("Ingrediente")]
        public int IdIngrediente { get; set; }
        public Ingrediente Ingrediente { get; set; }

        public double Cantidad { get; set; }
    }
}
