using System;
using System.Collections.Generic;
using Libreria2.Models;

namespace Libreria2.Models;

public partial class Ventas
{
    public int IdVenta { get; set; }

    public int? IdCliente { get; set; }

    public int? IdUsuario { get; set; }

    public decimal? Total { get; set; }

    public string? Observaciones { get; set; }

    public int? Estatus { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}