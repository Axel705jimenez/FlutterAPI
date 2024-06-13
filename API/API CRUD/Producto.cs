using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_CRUD
{
    public class Producto
    {
        [Key] 

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProducto { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public decimal precio { get; set; }

        public int stock { get; set; }

        public int estatus { get; set; }
    }
}
