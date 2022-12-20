using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Models;
using SistemaGestion.Repositories;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VentaController : Controller
    {
        VentaRepository repository = new VentaRepository();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Post([FromBody]Venta venta)
        {
            try
            {
                repository.RegistrarVenta(venta);
                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
