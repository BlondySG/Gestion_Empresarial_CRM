using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbEmpleadoSoporte
{
    public int IdEmpleadoSoporte { get; set; }

    public int IdEmpleado { get; set; }

    public int IdSoporte { get; set; }

    public virtual TbEmpleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual TbSoporte IdSoporteNavigation { get; set; } = null!;
}
