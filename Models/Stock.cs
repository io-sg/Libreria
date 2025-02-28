using System;
using System.Collections.Generic;
using Libreria2.Models;

namespace Libreria2.Models;

public partial class Stock
{
    public int IdStock { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public string? Observaciones { get; set; }

    public int? Estatus { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdUbicacion { get; set; }

    public int? IdAlmacen { get; set; }



    public virtual Producto? IdProductoNavigation { get; set; }
}