using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Libreria2.Models
{
    [Table("Productos", Schema = "dbo")]
    public class Producto
    {
        [Key]
        public int id_producto { get; set; }

        [Required]
        public string isbn { get; set; } = "N/A";

        [Required]
        public string titulo { get; set; } = "N/A";

        [Required]
        public string autor { get; set; } = "N/A";

        [Required]
        public string editorial { get; set; } = "N/A";

        [Required]
        public string precio_menudeo { get; set; } = "N/A";
        
        [Required]
        public string precio_mayoreo { get; set; } = "N/A";

        [Required]
        public string cantidad_mayoreo { get; set; } = "N/A";

        [Required]
        public DateTime fecha_registro { get; set; } = DateTime.Now;


    }
}
