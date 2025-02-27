using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Libreria2.Models
{
    [Table("almacen", Schema = "dbo")]
    public class Almacen
    {
        [Key]
        public int idAlmacen { get; set; }

        [Required]
        public string nombre { get; set; } = "N/A";

        private string? _observaciones;
        public string? observaciones
        {
            get => _observaciones;
            set => _observaciones = string.IsNullOrWhiteSpace(value) ? "N/A" : value;
        }

        [Required]
        public int status { get; set; } = 1;

        [Required]
        public DateTime fecha { get; set; } = DateTime.Now;

        [Required]
        public int idUsuario { get; set; } = 1;


    }
}
