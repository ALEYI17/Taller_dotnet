using System;
using System.Collections.Generic;

namespace Taller_DotNet_Rest.Model;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;
}
