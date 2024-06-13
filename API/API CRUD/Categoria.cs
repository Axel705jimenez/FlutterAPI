using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_CRUD
{
    public class Categoria
    {
        [Key] // Esto indica que idCliente es la clave primaria

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCategoria { get; set; }
        public string nombre { get; set; }
        public int estatus { get; set; }
    }
}
