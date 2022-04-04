namespace AgendaIatec.Models;

using System.ComponentModel.DataAnnotations;

public class AutenticateRequestModel
{
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Senha { get; set; }
}