﻿using Models.Parqueadero.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parqueadero.Interfaces
{
    public interface ITipoVehiculoApp
    {
        Task<List<TipoVehiculoDTO>> GetTiposVehiculos();
        Task<TipoVehiculoDTO> GetTipoVehiculoById(int id);
        Task<int> CreateTipoVehiculo(TipoVehiculoDTO tipoVehiculo);
        Task<int> EditTipoVehiculo(TipoVehiculoDTO tipoVehiculo);
        Task<int> DeleteTipoVehiculo(int id);
    }
}
