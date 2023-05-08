using System;
using System.Collections.Generic;

namespace Data.Parqueadero.Models;

public partial class Importe
{
    public int? IdRegistro { get; set; }

    public DateTime? FechaEntrada { get; set; }

    public DateTime? FechaSalida { get; set; }

    public string Placa { get; set; } = null!;

    public double? TiempoTotal { get; set; }

    public double? TiempoAcumulado { get; set; }

    public double? Importe1 { get; set; }

    public int? Estado { get; set; }

    public virtual Estado? EstadoNavigation { get; set; } 

    
}
