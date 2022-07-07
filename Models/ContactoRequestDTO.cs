using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class ContactoRequestDTO
    {
        [Required(ErrorMessage = "El Campo Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo Apellido es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Campo Telefono es Requerido")]
        public string Telefono { get; set; }

        public int IdCategoria { get; set; }
    }
}
