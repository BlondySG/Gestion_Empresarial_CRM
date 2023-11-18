using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbSoporteCliente
{
    public int IdSoporteCliente { get; set; }

    public int IdSoporteSc { get; set; }

    public int IdClienteSc { get; set; }

    public virtual TbCliente IdClienteScNavigation { get; set; } = null!;

    public virtual TbSoporte IdSoporteScNavigation { get; set; } = null!;
}
