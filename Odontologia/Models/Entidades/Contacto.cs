using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Odontologia.Models.Entidades
{
    public class Contacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_contacto { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? email { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? telefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string? mensaje { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime fecha { get; set; }
    }
}
