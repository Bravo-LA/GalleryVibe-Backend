using Azure;
using domain.entities;
using domain.repositories;
using Microsoft.AspNetCore.Mvc;

namespace presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicaController : ControllerBase
    {
        private readonly ITecnicaRepository _tecnicaRespository;

        public TecnicaController(ITecnicaRepository tecnicaRespository)
        {
            _tecnicaRespository = tecnicaRespository;
        }


        [HttpGet]
        public async Task<ActionResult<Response<List<Tecnica>>>> Listar()
        {
            try
            {
                var response = await _tecnicaRespository.Listar();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response<string>>> Agregar([FromBody] Tecnica tecnica)
        {
            try
            {
                var response = await _tecnicaRespository.Agregar(tecnica);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Response<string>>> Actualizar([FromBody] Tecnica tecnica)
        {
            try
            {
                var response = await _tecnicaRespository.Actualizar(tecnica);
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
                var response = await _tecnicaRespository.Eliminar(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
