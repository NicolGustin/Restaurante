using System.ComponentModel.DataAnnotations;

namespace Restaurante.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        [Required]
        public string NombreEmpresa { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
