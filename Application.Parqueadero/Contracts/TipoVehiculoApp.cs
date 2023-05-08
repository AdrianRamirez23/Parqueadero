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
    public class TipoVehiculoApp: ITipoVehiculoApp
    {
        private ITipoVehiculoSrv _tipoVehiculo;
        public TipoVehiculoApp(ITipoVehiculoSrv tipoVehiculo)
        {
            _tipoVehiculo = tipoVehiculo;
        }
        public async Task<List<TipoVehiculoDTO>> GetTiposVehiculos()
        {
            return await _tipoVehiculo.GetTiposVehiculos();
        }
        public async Task<TipoVehiculoDTO> GetTipoVehiculoById(int id)
        {
            return await _tipoVehiculo.GetTipoVehiculoById(id);
        }
        public async Task<int> CreateTipoVehiculo(TipoVehiculoDTO tipoVehiculo)
        {
            return await _tipoVehiculo.CreateTipoVehiculo(tipoVehiculo);
        }
        public async Task<int> EditTipoVehiculo(TipoVehiculoDTO tipoVehiculo)
        {
            return await _tipoVehiculo.EditTipoVehiculo(tipoVehiculo);
        }
        public async Task<int> DeleteTipoVehiculo(int id)
        {
            return await _tipoVehiculo.DeleteTipoVehiculo(id);
        }
    }
}
