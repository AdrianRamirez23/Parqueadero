using Models.Parqueadero.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Parqueadero.Interfaces
{
    public interface IRegistroSrv
    {
        Task<ResultDTO> RegistrarVehiculo(ImportesDTO importe);
        Task<ResultDTO> GenerarCierre(int mes);
    }
}
