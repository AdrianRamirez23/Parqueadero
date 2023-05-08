using Application.Parqueadero.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Parqueadero.DTOs;

namespace API.Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuariosController : ControllerBase
    {
        private readonly ITipoUsuarioApp _tipoUsuario;
        public TiposUsuariosController(ITipoUsuarioApp tipoUsuario)
        {
            _tipoUsuario = tipoUsuario;
        }

        [HttpGet]
        [Route("GetTiposUsuarios")]
        public async Task<IActionResult> GetTiposUsuarios() 
        {
            try
            {
                var result = await _tipoUsuario.GetTiposUsuarios();
                return Ok(result);
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetTipoUsuarioById/{id}")]
        public async Task<IActionResult> GetTipoUsuarioById(int id)
        {
            try
            {
                var result = await _tipoUsuario.GetTipoUsuarioById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateTipoUsuario")]
        public async Task<IActionResult> CreateTipoUsuario(TiposUsuariosDTO tipoUsuario) 
        {
            if(ModelState.IsValid) 
            {

                try
                {
                    HttpRequest request = HttpContext.Request;

                    var result = await _tipoUsuario.CreateTipoUsuario(tipoUsuario);
                    if (result == 0)
                        return BadRequest("Error al crear un tipo de usuario");
                  
                    return Created(new Uri(request.Host+"api/GetTiposUsuarios"), "Elementos creados "+ result);
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
        [Route("EditTipoUsuario")]
        public async Task<IActionResult> EditTipoUsuario(TiposUsuariosDTO tipoUsuario)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    var result = await _tipoUsuario.EditTipoUsuario(tipoUsuario);
                    if (result == 0)
                        return BadRequest("Error al editar un tipo de usuario");
                    if (result == -1)
                        return NotFound("Elemento no existe");

                    return Ok("Elementos editados "+ result);
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
        [Route("DeleteTipoUsuario/{id}")]
        public async Task<IActionResult> DeleteTipoUsuario(int id)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    var result = await _tipoUsuario.DeleteTipoUsuario(id);
                    if (result == 0)
                        return BadRequest("Error al eliminar un tipo de usuario");
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
