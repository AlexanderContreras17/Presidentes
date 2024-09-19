namespace Unidad2Ejercicio2.Models.ViewModels
{
    public class BiografiaViewModel
    {
        public int id { get; set; }
        public string Nombre { get; set; } = null!;
        public string FechaNacimiento { get; set; } = null!;
        public string FechaFalleciminto { get; set; } = null!;
        public string CiudadNacimiento { get; set; } = null!;
        public string EstadoNacimieto {  get; set; } = null!;
        public string Ocupacion { get; set; } = null!;
        public string InicioGobierno { get; set; } = null!;
        public string FinGobierno { get; set; } = null!;
        public string NombrePartido { get; set; } = null!;
        public int IdPartido {  get; set; }
        public string Biografia { get; set; } = null!;

    }
}