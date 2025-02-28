using System;
using System.Collections.Generic;
using Libreria2.Models;

namespace Libreria2.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdCliente { get; set; }

    public int? IdCompra { get; set; }

    public int? IdVenta { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaPago { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }

    public virtual Proveedores? IdProveedorNavigation { get; set; }

    public virtual Ventas? IdVentaNavigation { get; set; }
}