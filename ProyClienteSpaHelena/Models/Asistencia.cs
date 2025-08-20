﻿using System;
using System.Collections.Generic;

namespace ProySpaHelena.Models;

public partial class Asistencia
{
    public int Id { get; set; }

    public int TrabajadoraId { get; set; }

    public DateTime Fecha { get; set; }

    public DateTime? HoraEntrada { get; set; }

    public DateTime? HoraSalida { get; set; }

    public string? Observaciones { get; set; }

    public string? Estado { get; set; }

    public DateTime? RegistradaEn { get; set; }

}
