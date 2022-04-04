namespace AgendaIatec.Models;

public class AutenticateResponseModel
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string Token { get; set; }


    public AutenticateResponseModel(UsuarioModel usuario, string token)
    {
        Id = usuario.Id;
        Nome = usuario.Nome;
        Email = usuario.Email;
        Token = token;
    }
}