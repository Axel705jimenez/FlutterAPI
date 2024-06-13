using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_CRUD
{
    public class Usuario
    {

        [Key] 

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }

        public string nombreUsuario { get; set; }

        public string contrasena { get; set; }

        public string correo { get; set; }

        public string rol { get; set; }

        public int estatus { get; set; }
    }
}
