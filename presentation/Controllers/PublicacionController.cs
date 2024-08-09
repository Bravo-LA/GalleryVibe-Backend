using Azure;
using domain.entities;
using domain.repositories;
using Microsoft.AspNetCore.Mvc;

namespace presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionController : ControllerBase
    {
        private readonly IPublicacionRepository _publicacionRepository;

        public PublicacionController(IPublicacionRepository publicacionRepository)
        {
            _publicacionRepository = publicacionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Publicacion>>>> ObtenerTodos()
        {
            try
            {
                var response = await _publicacionRepository.ObtenerTodos();
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
                var response = await _publicacionRepository.ObtenerPorId(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response<string>>> Crear([FromBody] Publicacion publicacion)
        {
            try
            {
                var response = await _publicacionRepository.Crear(publicacion);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Response<string>>> Modificar([FromBody] Publicacion publicacion)
        {
            try
            {
                var response = await _publicacionRepository.ModificarPublicacion(pintura);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<string>>> EliminarPublicacion([FromRoute] int id)
        {
            try
            {
                var response = await _publicacionRepository.EliminarPublicacion(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
