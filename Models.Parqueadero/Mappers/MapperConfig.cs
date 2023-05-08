using AutoMapper;
using Data.Parqueadero.Models;
using Models.Parqueadero.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Parqueadero.Mappers
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<TiposUsuario, TiposUsuariosDTO>();
                cfg.CreateMap<TiposUsuariosDTO, TiposUsuario>();

                cfg.CreateMap<TipoVehiculoDTO, TiposVehiculo>();
                cfg.CreateMap<TiposVehiculo, TipoVehiculoDTO>();

                cfg.CreateMap<EstadosDTO, Estado>();
                cfg.CreateMap<Estado, EstadosDTO>();

                cfg.CreateMap<VehiculoDTO, Vehiculo>();
                cfg.CreateMap<Vehiculo, VehiculoDTO>();

                cfg.CreateMap<EmpleadosDTO, Empleado>();
                cfg.CreateMap<Empleado, EmpleadosDTO>();

                cfg.CreateMap<ImportesDTO, Importe>();
                cfg.CreateMap<Importe, ImportesDTO>();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
