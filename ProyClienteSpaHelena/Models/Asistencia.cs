using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProySpaHelena.Models;

public partial class Asistencia
{
    [JsonIgnore]
    public int Id { get; set; }

    public int TrabajadoraId { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan? HoraEntrada { get; set; }

    public TimeSpan? HoraSalida { get; set; }

    public string? Observaciones { get; set; }

    public string? Estado { get; set; }

}
