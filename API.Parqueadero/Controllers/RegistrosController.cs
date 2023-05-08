using Application.Parqueadero.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Parqueadero.DTOs;

namespace API.Parqueadero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly IRegistroApp _registro;
        public RegistrosController(IRegistroApp registro)
        {
            _registro = registro;
        }
        [HttpPost]
        [Route("RegistrarVehiculo")]
        public async Task<IActionResult> RegistrarVehiculo(ImportesDTO importe)
        {
            if (ModelState.IsValid)
            {
                var result = _registro.RegistrarVehiculo(importe);
                return Ok(result);
            }
            else
            {
                return BadRequest("Error en la petición");
            }
        }
        [HttpGet]
        [Route("GenerarCierre/{mes}")]
        public async Task<IActionResult> GenerarCierre(int mes) 
        {
            try
            {
                var result = _registro.GenerarCierre(mes);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetImportesPorMes/{mes}")]
        public async Task<IActionResult> GetImportesPorMes(int mes) 
        {
            try
            {
                var result = _registro.GetImportesPorMes(mes);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetImportesPorVehiculo/{placa}")]
        public async Task<IActionResult> GetImportesPorVehiculo(string placa)
        {
            try
            {
                var result = _registro.GetImportesPorVehiculo(placa);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
