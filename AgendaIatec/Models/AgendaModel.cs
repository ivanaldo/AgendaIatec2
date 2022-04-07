using System.ComponentModel.DataAnnotations;

namespace AgendaIatec.Models
{
    public class AgendaModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Quantidade máxima é 50 caracteres")]
        [MinLength(5, ErrorMessage = "Quantidade mínima é 5 caracteres")]
        public string? Nome { get; set; }

        [Required]
        public char? Tipo { get; set; }


        [MaxLength(250, ErrorMessage = "Quantidade máxima é 250 caracteres")]
        public string? Descricao { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Quantidade máxima é 100 caracteres")]
        public string? Local { get; set; }
        public List<ParticipantesModel> ParticipantesModel { get; set; }


    }
}
