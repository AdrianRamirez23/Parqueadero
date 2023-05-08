﻿using Models.Parqueadero.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Parqueadero.Interfaces
{
    public interface IVehiculoSrv
    {
        Task<List<VehiculoDTO>> GetVehiculos();
        Task<VehiculoDTO> GetVehiculoById(string placa);
        Task<int> CreateVehiculo(VehiculoDTO vehiculo);
        Task<int> EditVehiculo(VehiculoDTO vehiculo);
        Task<int> DeleteVehiculo(string placa);
    }
}
