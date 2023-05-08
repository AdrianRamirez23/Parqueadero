using System;
using System.Collections.Generic;

namespace Data.Parqueadero.Models;

public partial class Vehiculo
{
    public string Placa { get; set; } = null!;

    public int IdTipoVehiculo { get; set; }

    public virtual TiposVehiculo? IdTipoVehiculoNavigation { get; set; }

    
}
