using Azure;
using domain.entities;
using domain.repositories;
using Microsoft.AspNetCore.Mvc;

namespace presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {

        private readonly IGeneroRepository _generoRespository;

        public GeneroController(IGeneroRepository generoRespository)
        {
            _generoRespository = generoRespository;
        }


        [HttpGet]
        public async Task<ActionResult<Response<List<Genero>>>> Listar()
        {
            try
            {
                var response = await _generoRespository.Listar();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response<string>>> Agregar([FromBody] Genero genero)
        {
            try
            {
                var response = await _generoRespository.Agregar(genero);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Response<string>>> Actualizar([FromBody] Genero genero)
        {
            try
            {
                var response = await _generoRespository.Actualizar(genero);
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
                var response = await _generoRespository.Eliminar(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
