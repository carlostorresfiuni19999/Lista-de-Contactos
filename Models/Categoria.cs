using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo Nombre es Obligatorio")]
        public string? Nombre { get; set; }

        [Display(Name= "Fecha Creacion")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

    }
}
