using Microsoft.AspNetCore.Mvc;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClienteController : Controller
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
