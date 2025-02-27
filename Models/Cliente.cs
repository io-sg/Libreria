using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria2.Models
{
    [Table("Clientes", Schema = "dbo")]
    public class Cliente
    {
        [Key]
        public int id_cliente { get; set; }

        [Required]
        public string nombre { get; set; } = "N/A";

        [Required]
        [EmailAddress]
        public string correo { get; set; } = "N/A";

        [Required]
        public string telefono { get; set; } = "N/A";

        public string direccion { get; set; } = "N/A"; // Valor por defecto
    }
}
