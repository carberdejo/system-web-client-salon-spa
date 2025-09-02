﻿namespace ProyClienteSpaHelena.Models
{
    public class TrabajadorCreateDTO
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public int Dni { get; set; }

        public string Contrasena { get; set; } = null!;

        public int IdRol { get; set; }

        public DateTime? FechaInicio { get; set; }
        //

        public TimeSpan? HoraInicio { get; set; }

        public TimeSpan? HoraFin { get; set; }

        public DateTime? ValidoDesde { get; set; }
    }
}
