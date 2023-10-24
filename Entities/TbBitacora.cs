using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbBitacora
{
    public int IdBitacora { get; set; }

    public int CodError { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime FechaHora { get; set; }

    public string Origen { get; set; } = null!;

    public int IdEmpleado { get; set; }

    public virtual TbEmpleado IdEmpleadoNavigation { get; set; } = null!;
}
