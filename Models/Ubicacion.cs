using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Libreria2.Models
{
    [Table("ubicaciones", Schema = "dbo")]
    public class Ubicacion
    {
        [Key]
        public int idUbicacion { get; set; }

        [Required]
        public string descripcion { get; set; } = "N/A";

        [Required]
        public string observaciones { get; set; } = "N/A";

        [Required]
        public int estatus { get; set; } = 1;

        [Required]
        public DateTime fecha { get; set; } = DateTime.Now;

        [Required]
        public int idUsuario { get; set; } = 1;


    }
}
