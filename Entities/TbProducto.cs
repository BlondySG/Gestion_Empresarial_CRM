using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbProducto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal CostoProducto { get; set; }

    public int PuntoReorden { get; set; }

    public string NumParte { get; set; } = null!;

    public string? NumSerie { get; set; }

    public DateTime FechaFinGarantia { get; set; }

    public int IdProveedor { get; set; }

    public bool Activo { get; set; }

    public virtual TbProveedor IdProveedorNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleCompra> TbDetalleCompras { get; set; } = new List<TbDetalleCompra>();

    public virtual ICollection<TbDetalleVenta> TbDetalleVenta { get; set; } = new List<TbDetalleVenta>();
}
