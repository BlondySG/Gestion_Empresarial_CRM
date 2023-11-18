using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbVenta
{
    public int IdVenta { get; set; }

    public DateTime FechaVenta { get; set; }

    public decimal MontoTotal { get; set; }

    public string Estado { get; set; } = null!;

    public int IdClienteV { get; set; }

    public virtual TbCliente IdClienteVNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleVenta> TbDetalleVenta { get; set; } = new List<TbDetalleVenta>();
}
