using Application.Parqueadero.Interfaces;
using Models.Parqueadero.DTOs;
using Services.Parqueadero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parqueadero.Contracts
{
    public  class RegistroApp: IRegistroApp
    {
        private readonly IRegistroSrv _registro;
        public RegistroApp(IRegistroSrv registro)
        {
            _registro = registro;
        }
        public async Task<ResultDTO> RegistrarVehiculo(ImportesDTO importe) 
        {
            return await  _registro.RegistrarVehiculo(importe);
        }
        public async Task<ResultDTO> GenerarCierre(int mes) 
        {
            return await _registro.GenerarCierre(mes);
        }
        public async Task<List<ImportesDTO>> GetImportesPorMes(int mes) 
        {
            return await _registro.GetImportesPorMes(mes);
        }
        public async Task<ImportesDTO> GetImportesPorVehiculo(string placa) 
        {
            return await _registro.GetImportesPorVehiculo(placa);
        }
    }
}
