using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbDetalleCompra
{
    public int IdDetalleCompra { get; set; }

    public string NumFacturaCompra { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal ImpuestoCompra { get; set; }

    public decimal SubTotalCompra { get; set; }

    public decimal TotalCompra { get; set; }

    public int IdCompraP { get; set; }

    public int IdProductoP { get; set; }

    public virtual TbCompra IdCompraPNavigation { get; set; } = null!;

    public virtual TbProducto IdProductoPNavigation { get; set; } = null!;
}
