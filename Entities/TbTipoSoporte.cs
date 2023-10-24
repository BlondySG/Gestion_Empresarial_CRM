using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbTipoSoporte
{
    public int IdTipo { get; set; }

    public string NombreSoporte { get; set; } = null!;

    public virtual ICollection<TbSoporte> TbSoportes { get; set; } = new List<TbSoporte>();
}
