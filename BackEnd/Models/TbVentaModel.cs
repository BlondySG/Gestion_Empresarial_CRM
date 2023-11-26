namespace BackEnd.Models
{
    public class TbVentaModel
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; } = null!;
        public int IdClienteV { get; set; }
    }
}
