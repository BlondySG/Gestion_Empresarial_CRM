using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbEmpleadoSoporte
{
    public int IdEmpleadoSoporte { get; set; }

    public int IdEmpleadoEs { get; set; }

    public int IdSoporteEs { get; set; }

    public virtual TbEmpleado IdEmpleadoEsNavigation { get; set; } = null!;

    public virtual TbSoporte IdSoporteEsNavigation { get; set; } = null!;
}
