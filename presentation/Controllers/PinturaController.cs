using Azure;
using domain.entities;
using domain.repositories;
using Microsoft.AspNetCore.Mvc;

namespace presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinturaController : ControllerBase
    {
        private readonly IPinturaRepository _pinturaRespository;

        public PinturaController(IPinturaRepository pinturaRespository)
        {
            _pinturaRespository = pinturaRespository;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Pintura>>>> Listar()
        {
            try
            {
                var response = await _pinturaRespository.Listar();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Pintura>>> BuscarPorId([FromRoute] int id)
        {
            try
            {
                var response = await _pinturaRespository.BuscarPorIdUsuario(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response<string>>> Agregar([FromBody] Pintura pintura)
        {
            try
            {
                var response = await _pinturaRespository.Agregar(pintura);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Response<string>>> Actualizar([FromBody] Pintura pintura)
        {
            try
            {
                var response = await _pinturaRespository.Actualizar(pintura);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<string>>> Eliminar([FromRoute] int id)
        {
            try
            {
                var response = await _pinturaRespository.Eliminar(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
