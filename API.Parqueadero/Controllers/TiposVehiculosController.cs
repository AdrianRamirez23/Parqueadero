using Application.Parqueadero.Interfaces;
using Data.Parqueadero.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Parqueadero.DTOs;

namespace API.Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposVehiculosController : ControllerBase
    {
        private readonly ITipoVehiculoApp _tipoVehiculo;
        public TiposVehiculosController(ITipoVehiculoApp tipoVehiculo)
        {
            _tipoVehiculo = tipoVehiculo;
        }

        [HttpGet]
        [Route("GetTiposVehiculos")]
        public async Task<IActionResult> GetTiposVehiculos()
        {
            try
            {
                var result = await _tipoVehiculo.GetTiposVehiculos();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetTipoVehiculoById/{id}")]
        public async Task<IActionResult> GetTipoVehiculoById(int id)
        {
            try
            {
                var result = await _tipoVehiculo.GetTipoVehiculoById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateTipoVehiculo")]
        public async Task<IActionResult> CreateTipoVehiculo(TipoVehiculoDTO tipoVehiculo)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    HttpRequest request = HttpContext.Request;

                    var result = await _tipoVehiculo.CreateTipoVehiculo(tipoVehiculo);
                    if (result == 0)
                        return BadRequest("Error al crear un tipo de vehiculo");

                    return Created(new Uri(request.Host + "api/GetTiposVehiculos"), "Elementos creados " + result);
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
        [Route("EditTipoVehiculo")]
        public async Task<IActionResult> EditTipoVehiculo(TipoVehiculoDTO tipoVehiculo)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    var result = await _tipoVehiculo.EditTipoVehiculo(tipoVehiculo);
                    if (result == 0)
                        return BadRequest("Error al editar un tipo de vehículo");
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
        [Route("DeleteTipoVehiculo/{id}")]
        public async Task<IActionResult> DeleteTipoVehiculo(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var result = await _tipoVehiculo.DeleteTipoVehiculo(id);
                    if (result == 0)
                        return BadRequest("Error al eliminar un tipo de vehículo");
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
