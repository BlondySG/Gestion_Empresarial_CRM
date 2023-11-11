using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbArticulo
{
    public int IdArticulo { get; set; }

    public string NombreArticulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal CostoArticulo { get; set; }

    public int PuntoReorden { get; set; }

    public string NumParte { get; set; } = null!;

    public string? NumSerie { get; set; }

    public DateTime FechaFinGarantia { get; set; }

    public int IdProveedor { get; set; }

    public bool Activo { get; set; }

    //public virtual TbProveedor IdProveedorNavigation { get; set; } = null!;
    public virtual TbProveedor? IdProveedorNavigation { get; set; }

    public virtual ICollection<TbDatosCompra> TbDatosCompras { get; set; } = new List<TbDatosCompra>();

    public virtual ICollection<TbDatosVentum> TbDatosVenta { get; set; } = new List<TbDatosVentum>();
}
