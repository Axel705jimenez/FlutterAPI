using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_CRUD
{
    public class Cliente
    {

        [Key] 

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCliente { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }
        public string direccion { get; set; }

        [Required]
        [StringLength(10)] 
        public string telefono { get; set; }

        public string correo { get; set; }

        public int estatus { get; set; }
    }
}
