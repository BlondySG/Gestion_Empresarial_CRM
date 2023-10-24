using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbSoporteCliente
{
    public int IdSoporteCliente { get; set; }

    public int IdSoporte { get; set; }

    public int IdCliente { get; set; }

    public virtual TbCliente IdClienteNavigation { get; set; } = null!;

    public virtual TbSoporte IdSoporteNavigation { get; set; } = null!;
}
