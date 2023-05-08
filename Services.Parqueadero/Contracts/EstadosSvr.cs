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
    public class EstadosSvr:IEstadosSrv
    {
        private readonly ParqueaderoContext _context;
        private readonly Mapper _mapper;
        public EstadosSvr(ParqueaderoContext context)
        {
            _context = context;
            _mapper = MapperConfig.InitializeAutomapper();

        }
        public async Task<List<EstadosDTO>> GetEstados()
        {
            try
            {
                var estados = _context.Estados.ToList();
                return _mapper.Map<List<EstadosDTO>>(estados);

            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<EstadosDTO> GetEstadoById(int id)
        {
            try
            {
                var estado = _context.Estados.Where(a => a.IdEstado == id).FirstOrDefault();
                return _mapper.Map<EstadosDTO>(estado);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<int> CreateEstado(EstadosDTO estados)
        {
            try
            {
                var estado = _mapper.Map<Estado>(estados);
                _context.Estados.Add(estado);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<int> EditEstados(EstadosDTO estados)
        {
            try
            {
                if (_context.Estados.Any(a => a.IdEstado == estados.IdEstado))
                {
                    var estado = _mapper.Map<Estado>(estados);
                    _context.Estados.Update(estado);
                    return _context.SaveChanges();
                }
                return -1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<int> DeleteEstado(int id)
        {
            try
            {
                if (_context.Estados.Any(a => a.IdEstado == id))
                {
                    var estado = _context.Estados.Where(a => a.IdEstado == id).FirstOrDefault();
                    _context.Estados.Remove(estado);
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
