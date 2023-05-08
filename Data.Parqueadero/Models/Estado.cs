using System;
using System.Collections.Generic;

namespace Data.Parqueadero.Models;

public partial class Estado
{
    public int? IdEstado { get; set; }

    public string Estado1 { get; set; } 

    public virtual ICollection<Importe>? Importes { get; set; } 
}
