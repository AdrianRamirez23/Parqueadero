using Application.Parqueadero.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Parqueadero.DTOs;

namespace API.Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoApp _vehiculo;
        public VehiculosController(IVehiculoApp vehiculo)
        {
            _vehiculo = vehiculo;
        }

        [HttpGet]
        [Route("GetVehiculos")]
        public async Task<IActionResult> GetVehiculos()
        {
            try
            {
                var result = await _vehiculo.GetVehiculos();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetVehiculoById/{placa}")]
        public async Task<IActionResult> GetVehiculoById(string placa)
        {
            try
            {
                var result = await _vehiculo.GetVehiculoById(placa);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateVehiculo")]
        public async Task<IActionResult> CreateVehiculo(VehiculoDTO vehiculo)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    HttpRequest request = HttpContext.Request;

                    var result = await _vehiculo.CreateVehiculo(vehiculo);
                    if (result == 0)
                        return BadRequest("Error al crear un vehiculo");
                    if (result == -1)
                        return NotFound("No se encuentra el tipo de vehículo ingresado");

                    return Created(new Uri(request.Host + "api/GetVehiculos"), "Elementos creados " + result);
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
        [Route("EditVehiculo")]
        public async Task<IActionResult> EditVehiculo(VehiculoDTO vehiculo)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    var result = await _vehiculo.EditVehiculo(vehiculo);
                    if (result == 0)
                        return BadRequest("Error al editar un vehículo");
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
        [Route("DeleteVehiculo/{placa}")]
        public async Task<IActionResult> DeleteVehiculo(string placa)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var result = await _vehiculo.DeleteVehiculo(placa);
                    if (result == 0)
                        return BadRequest("Error al eliminar un vehículo");
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
