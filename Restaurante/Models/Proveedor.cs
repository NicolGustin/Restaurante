using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string NombreEmpresa { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
