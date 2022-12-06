using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Models;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductoVendidoController : Controller
    {
        [HttpPost]
        public ActionResult Post([FromBody] Venta venta)
        {
            return Ok();
        }
    }
}
