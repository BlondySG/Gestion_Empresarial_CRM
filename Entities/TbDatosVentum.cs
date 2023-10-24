using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbDatosVentum
{
    public int IdVenta { get; set; }

    public string NumFacturaVenta { get; set; } = null!;

    public DateTime? FechaCompra { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal ImpuestoVenta { get; set; }

    public decimal SubTotalVenta { get; set; }

    public decimal TotalVenta { get; set; }

    public DateTime FechaVenta { get; set; }

    public int IdArticulo { get; set; }

    public int IdCliente { get; set; }

    public virtual TbArticulo IdArticuloNavigation { get; set; } = null!;

    public virtual TbCliente IdClienteNavigation { get; set; } = null!;
}
