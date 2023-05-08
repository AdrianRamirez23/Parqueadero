using AutoMapper;
using Data.Parqueadero.Models;
using Microsoft.EntityFrameworkCore;
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
    public class TipoUsuarioSrv: ITipoUsuarioSrv
    {
        private readonly ParqueaderoContext _context;
        private readonly Mapper _mapper;
        public TipoUsuarioSrv(ParqueaderoContext context)
        {
            _context = context;
            _mapper = MapperConfig.InitializeAutomapper();

        }

        public async Task<List<TiposUsuariosDTO>> GetTiposUsuarios()
        {
            try
            {
                var tiposUsuarios = _context.TiposUsuarios.ToList();
                return _mapper.Map<List<TiposUsuariosDTO>>(tiposUsuarios);

            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<TiposUsuariosDTO> GetTipoUsuarioById(int id)
        {
            try
            {
                var tipoUsuario = _context.TiposUsuarios.Where(a => a.IdTipoUsuario == id).FirstOrDefault();
                return _mapper.Map<TiposUsuariosDTO>(tipoUsuario);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<int> CreateTipoUsuario(TiposUsuariosDTO tipoUsuario)
        {
            try
            {
                var tiposUsuario = _mapper.Map<TiposUsuario>(tipoUsuario);
                _context.TiposUsuarios.Add(tiposUsuario);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<int> EditTipoUsuario(TiposUsuariosDTO tipoUsuario)
        {
            try
            {
                if(_context.TiposUsuarios.Any(a => a.IdTipoUsuario == tipoUsuario.IdTipoUsuario)) 
                {
                    var tiposUsuario = _mapper.Map<TiposUsuario>(tipoUsuario);
                    _context.TiposUsuarios.Update(tiposUsuario);
                    return _context.SaveChanges();
                }
                return -1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<int> DeleteTipoUsuario(int id)
        {
            try
            {
                if (_context.TiposUsuarios.Any(a => a.IdTipoUsuario == id))
                {
                    var tiposUsuario = _context.TiposUsuarios.Where(a => a.IdTipoUsuario == id).FirstOrDefault();
                    _context.TiposUsuarios.Remove(tiposUsuario);
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
