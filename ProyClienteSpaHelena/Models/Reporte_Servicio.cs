namespace ProyClienteSpaHelena.Models
{
    public class Reporte_Servicio
    {
        public int id { get; set; }
        public string nombre { get; set; } = "";
        public int CantidadVariantes { get; set; }
        public decimal PrecioMinimo { get; set; }
        public decimal PrecioMaximo { get; set; }
    }
}
