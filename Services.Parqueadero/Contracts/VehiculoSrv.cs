using AutoMapper;
using Data.Parqueadero.Models;
using Models.Parqueadero.DTOs;
using Models.Parqueadero.Mappers;
using Services.Parqueadero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Parqueadero.Contracts
{
    public class VehiculoSrv: IVehiculoSrv
    {
        private readonly ParqueaderoContext _context;
        private readonly Mapper _mapper;
        public VehiculoSrv(ParqueaderoContext context)
        {
            _context = context;
            _mapper = MapperConfig.InitializeAutomapper();
        }
        public async Task<List<VehiculoDTO>> GetVehiculos()
        {
            try
            {
                var vehiculos = _context.Vehiculos.ToList();
                return _mapper.Map<List<VehiculoDTO>>(vehiculos);

            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<VehiculoDTO> GetVehiculoById(string placa)
        {
            try
            {
                var vehiculo = _context.Vehiculos.Where(a => a.Placa == placa).FirstOrDefault();
                return _mapper.Map<VehiculoDTO>(vehiculo);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<int> CreateVehiculo(VehiculoDTO vehiculo)
        {
            try
            {
                if (_context.TiposVehiculos.Any(a => a.IdTipoVehiculo == vehiculo.IdTipoVehiculo)) 
                {
                    var vehiculo1 = _mapper.Map<Vehiculo>(vehiculo);
                    _context.Vehiculos.Add(vehiculo1);
                    return _context.SaveChanges();
                }

                return -1;
              
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<int> EditVehiculo(VehiculoDTO vehiculo)
        {
            try
            {
                if (_context.Vehiculos.Any(a => a.Placa == vehiculo.Placa) && _context.TiposVehiculos.Any(a => a.IdTipoVehiculo == vehiculo.IdTipoVehiculo))
                {
                    var vehiculo1 = _mapper.Map<Vehiculo>(vehiculo);
                    _context.Vehiculos.Update(vehiculo1);
                    return _context.SaveChanges();
                }
                return -1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<int> DeleteVehiculo(string placa)
        {
            try
            {
                if (_context.Vehiculos.Any(a => a.Placa == placa))
                {
                    var vehiculo = _context.Vehiculos.Where(a => a.Placa == placa).FirstOrDefault();
                    _context.Vehiculos.Remove(vehiculo);
                    return _context.SaveChanges();
                }
                return -1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
    }
}
