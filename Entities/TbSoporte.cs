using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbSoporte
{
    public int IdSoporte { get; set; }

    public string DescripcionSoporte { get; set; } = null!;

    public DateTime FechaAgendada { get; set; }

    public DateTime? FechaCierreSoporte { get; set; }

    public string Estatus { get; set; } = null!;

    public int IdTipoS { get; set; }

    public virtual TbTipoSoporte IdTipoSNavigation { get; set; } = null!;

    public virtual ICollection<TbEmpleadoSoporte> TbEmpleadoSoportes { get; set; } = new List<TbEmpleadoSoporte>();

    public virtual ICollection<TbSoporteCliente> TbSoporteClientes { get; set; } = new List<TbSoporteCliente>();
}
