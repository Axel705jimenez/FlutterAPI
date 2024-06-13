using System.ComponentModel.DataAnnotations;

public class DetallePedido
{
    [Key]
    public int idDetallePedido { get; set; }
    public string nombreProducto { get; set; }
    public int cantidad { get; set; }
    public decimal precioUnitario { get; set; }
    public int estatus { get; set; }
}
