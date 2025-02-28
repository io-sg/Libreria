using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria2.Models
{
    [Table("Promociones", Schema = "dbo")]
    public class Promocion
    {
        [Key]
        public int id_promocion { get; set; }

        [Key]
        public int id_producto { get; set; }

        [Required]
        public string fechainicio { get; set; } = "N/A";

        [Required]
        public string fechafin { get; set; } = "N/A";

        [Required]
        public int descuento { get; set; } = 0;

        public string indefinida { get; set; } = "N/A"; // Valor por defecto
    }
}
