using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Models;
using SistemaGestion.Repositories;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductosController : Controller
    {
        private ProductosRepository repository = new ProductosRepository();

        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            try
            {
                List<Producto> lista = repository.listarProductos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            try
            {
                Producto? producto = repository.obtenerProducto(id);
                if (producto != null)
                {
                    return Ok(producto);
                }
                else
                {
                    return NotFound("El producto no fue encontrado");
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Producto producto)
        {
            try
            {
                Producto productoCreado = repository.crearProducto(producto);
                return StatusCode(StatusCodes.Status201Created, productoCreado);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetProducto/{id}")]
        public ActionResult<Producto> GetProducto(int id)
        {
            try
            {
                Producto? producto = repository.obtenerProducto(id);
                if (producto != null)
                {
                    return Ok(producto);
                }
                else
                {
                    return NotFound("El producto no fue encontrado");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody]int id)
        {
            try
            {
                bool seElimino = repository.eliminarProducto(id);
                if (seElimino)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
