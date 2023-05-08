using Application.Parqueadero.Interfaces;
using Data.Parqueadero.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Parqueadero.DTOs;

namespace API.Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosApp _empleado;
        public EmpleadosController(IEmpleadosApp empleado)
        {
            _empleado = empleado;
        }
        [HttpGet]
        [Route("GetEmpleados")]
        public async Task<IActionResult> GetEmpleados() 
        {
            try
            {
                var result = await _empleado.GetEmpleados();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetEmpleadosById/{id}")]
        public async Task<IActionResult> GetEmpleadosById(string id)
        {
            try
            {
                var result = await _empleado.GetEmpleadosById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("CreateEmpleados")]
        public async Task<IActionResult> CreateEmpleados(EmpleadosDTO empleados)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    HttpRequest request = HttpContext.Request;

                    var result = await _empleado.CreateEmpleados(empleados);
                    if (result == 0)
                        return BadRequest("Error al crear un empleado");

                    return Created(new Uri(request.Host + "api/GetEmpleados"), "Elementos creados " + result);
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
        [Route("EditEmpleados")]
        public async Task<IActionResult> EditEmpleados(EmpleadosDTO empleados)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var result = await _empleado.EditEmpleados(empleados);
                    if (result == 0)
                        return BadRequest("Error al editar un empleado");

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
        [Route("DeleteEmpleados/{id}")]
        public async Task<IActionResult> DeleteEmpleados(string id) 
        {
            if (!string.IsNullOrEmpty(id))
            {

                try
                {

                    var result = await _empleado.DeleteEmpleados(id);
                    if (result == 0)
                        return BadRequest("Error al eliminar un empleado");
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
