using System;
using System.Collections.Generic;

namespace Data.Parqueadero.Models;

public partial class Empleado
{
    public string Id { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int TipoUsuario { get; set; }

    public virtual TiposUsuario? TipoUsuarioNavigation { get; set; }
}
