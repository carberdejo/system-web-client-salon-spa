﻿using System;
using System.Collections.Generic;

namespace ProySpaHelena.Models;

public partial class Trabajadora
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public int Dni { get; set; }

    public string Contrasena { get; set; } = null!;

    public int IdRol { get; set; }

    public string? Activa { get; set; }

    public DateTime? FechaInicio { get; set; }
}
