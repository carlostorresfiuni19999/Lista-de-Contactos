using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Models
{
    [Table("Contactos")]
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El Campo Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="El Campo Apellido es requerido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage ="El Campo Telefono es Requerido")]
        public string Telefono { get; set; }
        [Display(Name = "Fecha Creacion")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
        public Categoria? Categoria { get; set; }

        [ForeignKey("Categoria")]
        public int? IdCategoria { get; set; }


    }
}
