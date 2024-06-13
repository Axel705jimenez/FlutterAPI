using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_CRUD
{
    public class Pedido
    {
        [Key] // Esto indica que idCliente es la clave primaria

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPedido { get; set; }

        public string fecha { get; set; }

        public string direccion { get; set; }

        public int estatus { get; set; }


    }
}
