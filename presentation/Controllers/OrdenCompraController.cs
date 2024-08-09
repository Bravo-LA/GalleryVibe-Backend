using Azure;
using domain.entities;
using domain.repositories;
using Microsoft.AspNetCore.Mvc;

namespace presentation.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraController : ControllerBase
    {

        private readonly IOrdenCompraRepository _OrdenCompraRespository;

        public OrdenCompraController(IOrdenCompraRepository ordencompraRespository)
        {
            _OrdenCompraRespository = ordencompraRespository;
        }


        [HttpGet]
        public async Task<ActionResult<Response<List<OrdenCompra>>>> Listar()
        {
            try
            {
                var response = await _OrdenCompraRespository.Listar();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response<string>>> Agregar([FromBody] OrdenCompra genero)
        {
            try
            {
                var response = await _OrdenCompraRespository.Agregar(genero);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Response<string>>> Actualizar([FromBody] OrdenCompra ordenCompra)
        {
            try
            {
                var response = await _OrdenCompraRespository.Actualizar(ordenCompra);
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
                var response = await _OrdenCompraRespository.Eliminar(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}