using Azure;
using domain.entities;
using domain.repositories;
using Microsoft.AspNetCore.Mvc;

namespace presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRespository;

        public UsuarioController(IUsuarioRepository usuarioRespository)
        {
            _usuarioRespository = usuarioRespository;
        }

        [HttpGet]
        public async Task<ActionResult<Response<List<Usuario>>>> Listar()
        {
            try
            {
                var response = await _usuarioRespository.Listar();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response<Usuario>>> BuscarPorId([FromRoute] int id)
        {
            try
            {
                var response = await _usuarioRespository.BuscarPorId(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response<string>>> Agregar([FromBody] Usuario usuario)
        {
            try
            {
                var response = await _usuarioRespository.Agregar(usuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response<string>>> Login([FromBody] Credenciales credenciales)
        {
            try
            {
                var response = await _usuarioRespository.Login(credenciales);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Response<string>>> Actualizar([FromBody] Usuario usuario)
        {
            try
            {
                var response = await _usuarioRespository.Actualizar(usuario);
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
                var response = await _usuarioRespository.Eliminar(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
