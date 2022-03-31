using AgendaIatec.Context;
using AgendaIatec.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaIatec.Controllers
{
  
    public class UsuariosController : ControllerBase
    {
     
      
        public async Task<string> PostAsync(UsuarioModel usuario, Contexto contexto )
        {
            contexto.UsuarioModels.Add(usuario);
            await contexto.SaveChangesAsync();

            return "Usuario cadastrado com sucesso!";
        }
    }
}