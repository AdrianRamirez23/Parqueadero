using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Parqueadero.Models;

public partial class TiposUsuario
{
    
    public int? IdTipoUsuario { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public virtual ICollection<Empleado>? Empleados { get; set; }
}
