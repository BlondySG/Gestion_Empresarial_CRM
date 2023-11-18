using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbCompra
{
    public int IdCompra { get; set; }

    public DateTime FechaCompra { get; set; }

    public decimal MontoTotal { get; set; }

    public string Estado { get; set; } = null!;

    public int IdProveedorC { get; set; }

    public virtual TbProveedor IdProveedorCNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleCompra> TbDetalleCompras { get; set; } = new List<TbDetalleCompra>();
}
