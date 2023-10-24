using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbProveedor
{
    public int IdProveedor { get; set; }

    public string NombreProveedor { get; set; } = null!;

    public string CorreoProveedor { get; set; } = null!;

    public string NombreContacto { get; set; } = null!;

    public string DireccionProveedor { get; set; } = null!;

    public string TelefonoProveedor { get; set; } = null!;

    public string ProductoProveedor { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<TbArticulo> TbArticulos { get; set; } = new List<TbArticulo>();

    public virtual ICollection<TbDatosCompra> TbDatosCompras { get; set; } = new List<TbDatosCompra>();
}
