using Azure;
using domain.entities;
using domain.repositories;
using Microsoft.AspNetCore.Mvc;

namespace presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentasRepository _ventasRepository;

        public VentasController(IVentasRepository ventasRepository)
        {
            _ventasRepository = ventasRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Publicacion>>>> ObtenerTodos()
        {
            try
            {
                var response = await _ventasRepository.ObtenerTodos();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Pintura>>> ObtenerPorId([FromRoute] int id)
        {
            try
            {
                var response = await _ventasRepository.ObtenerPorId(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response<string>>> Crear([FromBody] Ventas ventas)
        {
            try
            {
                var response = await _ventasRepository.Crear(ventas);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
