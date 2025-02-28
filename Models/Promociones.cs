using System;
using System.Collections.Generic;
using Libreria2.Models;

namespace Libreria2.Models;

public partial class Promociones
{
    public int IdPromocion { get; set; }

    public int? IdProducto { get; set; }

    public decimal? Descuento { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Observaciones { get; set; }

    public int? Estatus { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}