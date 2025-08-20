using System;
using System.Collections.Generic;

namespace ProySpaHelena.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public int ClienteId { get; set; }

    public int RecepcionistaId { get; set; }

    public DateTime Fecha { get; set; }

    public string? Estado { get; set; }

    public string? Notas { get; set; }

    public int TrabajadoraId { get; set; }
}
