using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Models;
using SistemaGestion.Repositories;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : Controller
    {
        LoginRepository repository = new LoginRepository();

        [HttpPost]
        public ActionResult<Usuario> Login(Usuario usuario)
        {
            try
            {
                // Método que verifique el usuario
                // Método que me dé un token *
                bool usuarioExiste = repository.verificarUsuario(usuario);
                return usuarioExiste ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
