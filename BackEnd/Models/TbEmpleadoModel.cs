namespace BackEnd.Models
{
    public class TbEmpleadoModel
    {
        public int IdEmpleado { get; set; }
        public string Cedula { get; set; } = null!;
        public string? RutaFoto { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public string TelefonoEmpleado { get; set; } = null!;
        public string CorreoEmpleado { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string NombreContacto { get; set; } = null!;
        public string TelefonoContacto { get; set; } = null!;
        public bool Activo { get; set; }
        public int IdRol { get; set; }
    }
}
