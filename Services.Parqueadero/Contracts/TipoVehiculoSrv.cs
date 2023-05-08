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
    public class TipoVehiculoSrv: ITipoVehiculoSrv
    {
        private readonly ParqueaderoContext _context;
        private readonly Mapper _mapper;
        public TipoVehiculoSrv(ParqueaderoContext context)
        {
            _context = context;
            _mapper = MapperConfig.InitializeAutomapper();
        }
        public async Task<List<TipoVehiculoDTO>> GetTiposVehiculos()
        {
            try
            {
                var tiposVehiculos = _context.TiposVehiculos.ToList();
                return _mapper.Map<List<TipoVehiculoDTO>>(tiposVehiculos);

            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<TipoVehiculoDTO> GetTipoVehiculoById(int id)
        {
            try
            {
                var tiposVehiculo = _context.TiposVehiculos.Where(a => a.IdTipoVehiculo == id).FirstOrDefault();
                return _mapper.Map<TipoVehiculoDTO>(tiposVehiculo);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<int> CreateTipoVehiculo(TipoVehiculoDTO tipoVehiculo)
        {
            try
            {
                var tiposVehiculo = _mapper.Map<TiposVehiculo>(tipoVehiculo);
                _context.TiposVehiculos.Add(tiposVehiculo);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<int> EditTipoVehiculo(TipoVehiculoDTO tipoVehiculo)
        {
            try
            {
                if (_context.TiposVehiculos.Any(a => a.IdTipoVehiculo ==  tipoVehiculo.IdTipoVehiculo))
                {
                    var tiposVehiculo = _mapper.Map<TiposVehiculo>(tipoVehiculo);
                    _context.TiposVehiculos.Update(tiposVehiculo);
                    return _context.SaveChanges();
                }
                return -1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<int> DeleteTipoVehiculo(int id)
        {
            try
            {
                if (_context.TiposVehiculos.Any(a => a.IdTipoVehiculo == id))
                {
                    var tiposVehiculo = _context.TiposVehiculos.Where(a => a.IdTipoVehiculo == id).FirstOrDefault();
                    _context.TiposVehiculos.Remove(tiposVehiculo);
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
