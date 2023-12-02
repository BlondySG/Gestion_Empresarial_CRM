using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class TbClienteViewModel
    {
        [Key]
        [Display(Name = "Id Cliente")]
        public int IdCliente { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Es obligatorio agregar el nombre")]
        [StringLength(70, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        public string NombreCliente { get; set; } = null!;

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "Es obligatorio agregar el correo")]
        [StringLength(75, ErrorMessage = "{0} no debe tener mas de 75 caracteres")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "{0} debe ser un correo válido")]
        public string CorreoCliente { get; set; } = null!;

        [Display(Name = "Contacto")]
        [Required(ErrorMessage = "Es obligatorio agregar el nombre del contacto")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        public string PersonaContacto { get; set; } = null!;

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Es obligatorio agregar la dirección del cliente")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "{0} debe tener mas de cinco caracteres")]
        public string DireccionCliente { get; set; } = null!;

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Es obligatorio agregar el teléfono")]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "{0} debe tener mas de ocho números")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{8,11}$", ErrorMessage = "Ingresa un teléfono válido")]
        public string TelefonoCliente { get; set; } = null!;

        public bool Activo { get; set; }
    }
}
