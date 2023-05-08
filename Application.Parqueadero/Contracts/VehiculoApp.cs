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
    public class VehiculoApp: IVehiculoApp
    {

        private IVehiculoSrv _vehiculo;
        public VehiculoApp(IVehiculoSrv vehiculo)
        {
            _vehiculo = vehiculo;
        }
        public async Task<List<VehiculoDTO>> GetVehiculos()
        {
            return await _vehiculo.GetVehiculos();
        }
        public async Task<VehiculoDTO> GetVehiculoById(string placa)
        {
            return await _vehiculo.GetVehiculoById(placa);
        }
        public async Task<int> CreateVehiculo(VehiculoDTO vehiculo)
        {
            return await _vehiculo.CreateVehiculo(vehiculo);
        }
        public async Task<int> EditVehiculo(VehiculoDTO vehiculo)
        {
            return await _vehiculo.EditVehiculo(vehiculo);
        }
        public async Task<int> DeleteVehiculo(string placa)
        {
            return await _vehiculo.DeleteVehiculo(placa);
        }
    }
}
