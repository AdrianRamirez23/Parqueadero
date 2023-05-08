using Application.Parqueadero.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Parqueadero.DTOs;

namespace API.Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadosApp _estados;
        public EstadosController(IEstadosApp estados)
        {
            _estados = estados;
        }

        [HttpGet]
        [Route("GetEstados")]
        public async Task<IActionResult> GetEstados()
        {
            try
            {
                var result = await _estados.GetEstados();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetEstadoById/{id}")]
        public async Task<IActionResult> GetEstadoById(int id)
        {
            try
            {
                var result = await _estados.GetEstadoById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateEstado")]
        public async Task<IActionResult> CreateEstado(EstadosDTO estados)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    HttpRequest request = HttpContext.Request;

                    var result = await _estados.CreateEstado(estados);
                    if (result == 0)
                        return BadRequest("Error al crear un estado");

                    return Created(new Uri(request.Host + "api/GetEstados"), "Elementos creados " + result);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Petición errada.");
            }
        }
        [HttpPut]
        [Route("EditEstados")]
        public async Task<IActionResult> EditEstados(EstadosDTO estados)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    var result = await _estados.EditEstados(estados);
                    if (result == 0)
                        return BadRequest("Error al editar un estado");
                    if (result == -1)
                        return NotFound("Elemento no existe");

                    return Ok("Elementos editados " + result);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Petición errada.");
            }
        }
        [HttpDelete]
        [Route("DeleteEstado/{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    var result = await _estados.DeleteEstado(id);
                    if (result == 0)
                        return BadRequest("Error al eliminar un estado");
                    if (result == -1)
                        return NotFound("Elemento no existe");

                    return Ok("Elementos eliminados " + result);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Petición errada.");
            }
        }
    }
}
