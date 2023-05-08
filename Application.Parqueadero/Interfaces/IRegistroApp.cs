using Models.Parqueadero.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parqueadero.Interfaces
{
    public interface IRegistroApp
    {
        Task<ResultDTO> RegistrarVehiculo(ImportesDTO importe);
        Task<ResultDTO> GenerarCierre(int mes);
        Task<List<ImportesDTO>> GetImportesPorMes(int mes);
        Task<ImportesDTO> GetImportesPorVehiculo(string placa);
    }
}
