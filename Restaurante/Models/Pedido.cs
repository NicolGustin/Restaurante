using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        [ForeignKey("Proveedor")]
        public int IdProveedor { get; set; }
        public Proveedor Proveedor { get; set; }

        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }
    }
}
