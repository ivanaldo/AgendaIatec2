namespace AgendaIatec.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AgendaIatec.Helpers;
using AgendaIatec.Models;

public interface IUserService
{
    AutenticateResponseModel Authenticate(AutenticateRequestModel model);
    IEnumerable<UsuarioModel> GetAll();
    UsuarioModel GetById(int id);
}

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<UsuarioModel> _users = new List<UsuarioModel>
    {
       // new UsuarioModel { Id = 1, Nome = "nome teste", Email = "email@email.com", Senha = "senha" }
    };

    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public AutenticateResponseModel Authenticate(AutenticateRequestModel model)
    {
        var user = _users.SingleOrDefault(x => x.Email == model.Email && x.Senha == model.Senha);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AutenticateResponseModel(user, token);
    }

    public IEnumerable<UsuarioModel> GetAll()
    {
        return _users;
    }

    public UsuarioModel GetById(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }

    // helper methods

    private string generateJwtToken(UsuarioModel user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}