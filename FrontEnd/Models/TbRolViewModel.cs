using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class TbRolViewModel
    {
        [Key]
        [Display(Name = "Id Rol")]
        public int IdRol { get; set; }

        [Display(Name = "Nombre Rol")]
        [Required(ErrorMessage = "{0} es requerido")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "{0} debe tener mas de tres carateres")]
        [DataType(DataType.Text)]
        public string NombreRol { get; set; } = null!;

        [Display(Name = "Activo")]
        public bool Activo { get; set; }
    }
}
