using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class TbEmpleadoViewModel
    {

        [Key]
        [Display(Name = "Id Empleado")]
        public int IdEmpleado { get; set; }

        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "{0} es requerida")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "{0} debe tener mas de nueve carateres")]
        [RegularExpression("([0-9]+)")]
        public string Cedula { get; set; } = null!;

        [Display(Name = "Foto")]
        public string? RutaFoto { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Es obligatorio agregar el nombre")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "Es obligatorio agregar el apellido")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        public string Apellido1 { get; set; } = null!;

        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "Es obligatorio agregar el apellido")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        public string Apellido2 { get; set; } = null!;

        [Display(Name = "Teléfono Empleado")]
        [Required(ErrorMessage = "Es obligatorio agregar el teléfono")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "{0} debe tener mas de ocho números")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{8,11}$", ErrorMessage = "Ingresa un teléfono válido")]
        public string TelefonoEmpleado { get; set; } = null!;

        [Display(Name = "Correo Empleado")]
        [Required(ErrorMessage = "Es obligatorio agregar el correo")]
        [StringLength(75, ErrorMessage = "{0} no debe tener mas de 75 caracteres")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "{0} debe ser un correo válido")]
        public string CorreoEmpleado { get; set; } = null!;

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Es obligatorio agregar la dirección")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "{0} debe tener mas de cinco caracteres")]
        public string Direccion { get; set; } = null!;

        [Display(Name = "Nombre Contacto")]
        [Required(ErrorMessage = "Es obligatorio agregar el nombre del contacto")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        public string NombreContacto { get; set; } = null!;

        [Display(Name = "Teléfono Contacto")]
        [Required(ErrorMessage = "Es obligatorio agregar el teléfono")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "{0} debe tener mas de ocho números")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{8,11}$", ErrorMessage = "Ingresa un teléfono válido")]
        public string TelefonoContacto { get; set; } = null!;

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int IdRol { get; set; }
        public IEnumerable<TbRolViewModel> Roles { get; set; }
        //public List<TbRolViewModel> Roles { get; set; }
        public TbRolViewModel TbRol { get; set; }
    }
}
