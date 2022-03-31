using System.ComponentModel.DataAnnotations;

namespace AgendaIatec.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Quantidade máxima é 50 caracteres")]
        [MinLength(5, ErrorMessage = "Quantidade mínima é 5 caracteres")]
        public string? Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido!")]
        public string? Email { get; set; }

        public DateTime DataNascimento { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Quantidade mínima é 6 caracteres")]
        public string? Senha { get; set; }

        public Char Genero { get; set; }

    }
}
