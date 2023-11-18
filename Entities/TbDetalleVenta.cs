using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbDetalleVenta
{
    public int IdDetalleVenta { get; set; }

    public string NumFacturaVenta { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal ImpuestoVenta { get; set; }

    public decimal SubTotalVenta { get; set; }

    public decimal TotalVenta { get; set; }

    public int IdVentaC { get; set; }

    public int IdProductoC { get; set; }

    public virtual TbProducto IdProductoCNavigation { get; set; } = null!;

    public virtual TbVenta IdVentaCNavigation { get; set; } = null!;
}
