using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbDatosCompra
{
    public int IdCompra { get; set; }

    public string NumFacturaCompra { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal ImpuestoCompra { get; set; }

    public decimal SubTotalCompra { get; set; }

    public decimal TotalCompra { get; set; }

    public DateTime FechaCompra { get; set; }

    public int IdProveedor { get; set; }

    public int IdArticulo { get; set; }

    public virtual TbArticulo IdArticuloNavigation { get; set; } = null!;

    public virtual TbProveedor IdProveedorNavigation { get; set; } = null!;
}
