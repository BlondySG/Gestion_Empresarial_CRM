using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontEnd.Models
{
    public class TbVentaViewModel
    {

        [Key]
        [Display(Name = "Id Venta")]
        public int IdVenta { get; set; }

        [Display(Name = "Fecha de venta")]
        [Required(ErrorMessage = "{0} es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaVenta { get; set; }

        [Display(Name = "Monto Total")]
        [Range(0, 10000000)]
        [DisplayFormat(DataFormatString = "{0:₡0.00}", ApplyFormatInEditMode = false, NullDisplayText = "Sin valor asignado")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal MontoTotal { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Es obligatorio agregar el estado")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} debe tener mas de dos carateres")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letras solamente")]
        public string Estado { get; set; } = null!;

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Es obligatorio agregar el cliente")]
        public int IdClienteV { get; set; }

        public IEnumerable<TbClienteViewModel> Clientes { get; set; }
        //public List<TbRolViewModel> Roles { get; set; }
        public TbClienteViewModel TbCliente{ get; set; }
    }
}
