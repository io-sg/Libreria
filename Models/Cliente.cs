using System;
using System.Collections.Generic;

namespace Libreria2.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Rfc { get; set; }

    public string? Observaciones { get; set; }

    public int? Estatus { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}