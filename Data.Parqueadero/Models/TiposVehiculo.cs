using System;
using System.Collections.Generic;

namespace Data.Parqueadero.Models;

public partial class TiposVehiculo
{
    public int? IdTipoVehiculo { get; set; }

    public string TipoVehiculo { get; set; } = null!;

    public double ImportePorMinuto { get; set; }

    public virtual ICollection<Vehiculo>? Vehiculos { get; set; } 
}
