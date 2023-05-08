using AutoMapper;
using Data.Parqueadero.Models;
using Models.Parqueadero.DTOs;
using Models.Parqueadero.EncodeString;
using Models.Parqueadero.Mappers;
using Services.Parqueadero.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Parqueadero.Contracts
{
    public class EmpleadosSrv : IEmpleadosSrv
    {
        private readonly ParqueaderoContext _context;
        private readonly Mapper _mapper;
        private readonly IEncondeString _encoding;
        public EmpleadosSrv(ParqueaderoContext context, IEncondeString encondeString)
        {
            _context = context;
            _mapper = MapperConfig.InitializeAutomapper();
            _encoding = encondeString;

        }
        public async Task<List<EmpleadosDTO>> GetEmpleados()
        {
            try
            {
                var empleados = _context.Empleados.ToList();
                return _mapper.Map<List<EmpleadosDTO>>(empleados);

            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<EmpleadosDTO> GetEmpleadosById(string id)
        {
            try
            {
                var empleado = _context.Empleados.Where(a => a.Id == id).FirstOrDefault();
                return _mapper.Map<EmpleadosDTO>(empleado);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<int> CreateEmpleados(EmpleadosDTO empleados) 
        {
            try
            {
                empleados.Contrasena = _encoding.EncodeStrToBase64(empleados.Contrasena);
                var empleado = _mapper.Map<Empleado>(empleados);
                _context.Empleados.Add(empleado);
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<int> EditEmpleados(EmpleadosDTO empleados)
        {
            try
            {
                if (_context.Empleados.Any(a => a.Id == empleados.Id))
                {
                    empleados.Contrasena = _context.Empleados.Where(a => a.Id == empleados.Id).FirstOrDefault().Contrasena != empleados.Contrasena ? _encoding.EncodeStrToBase64(empleados.Contrasena): empleados.Contrasena;
                    var empleado = _mapper.Map<Empleado>(empleados);
                    _context.Empleados.Update(empleado);
                    return _context.SaveChanges();
                }
                return -1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
        public async Task<int> DeleteEmpleados(string id)
        {
            try
            {
                if (_context.Empleados.Any(a => a.Id == id))
                {
                    var empleado = _context.Empleados.Where(a => a.Id == id).FirstOrDefault();
                    _context.Empleados.Remove(empleado);
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
