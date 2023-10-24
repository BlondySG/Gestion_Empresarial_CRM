using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbEmpleado
{
    public int IdEmpleado { get; set; }

    public string Cedula { get; set; } = null!;

    public string? Foto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string Apellido2 { get; set; } = null!;

    public string TelefonoEmpleado { get; set; } = null!;

    public string CorreoEmpleado { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string NombreContacto { get; set; } = null!;

    public string TelefonoContacto { get; set; } = null!;

    public bool Activo { get; set; }

    public int IdRol { get; set; }

    public virtual TbRol IdRolNavigation { get; set; } = null!;

    public virtual ICollection<TbBitacora> TbBitacoras { get; set; } = new List<TbBitacora>();

    public virtual ICollection<TbEmpleadoSoporte> TbEmpleadoSoportes { get; set; } = new List<TbEmpleadoSoporte>();

    public virtual ICollection<TbSoporte> TbSoportes { get; set; } = new List<TbSoporte>();
}
