using AutoMapper;
using Data.Parqueadero.Models;
using Microsoft.Win32;
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
    public class RegistroSrv: IRegistroSrv
    {
        private readonly ParqueaderoContext _context;
        private readonly Mapper _mapper;
        public RegistroSrv(ParqueaderoContext context)
        {
            _context = context;
            _mapper = MapperConfig.InitializeAutomapper();

        }
        public async Task<ResultDTO> RegistrarVehiculo(ImportesDTO importe)
        {
            try
            {
               var registro = _context.Importes.Where(a => a.Placa.ToUpper() == importe.Placa.ToUpper()).ToList().Max();

                if(registro == null || registro.Estado != 1) 
                {
                    importe.Estado = 1;
                    importe.FechaEntrada = DateTime.UtcNow;
                    importe.FechaSalida = null;
                    importe.Placa = importe.Placa.ToUpper();
                    var importes = _mapper.Map<Importe>(importe);
                    _context.Importes.Add(importes);

                }
                

                if (registro != null && registro.Estado != 2)
                {
                    
                    registro.FechaSalida = DateTime.UtcNow.AddMinutes(35);
                    registro.TiempoTotal = !_context.Vehiculos.Any(a => a.Placa.ToUpper().Equals(importe.Placa.ToUpper())) ? (registro.FechaSalida - registro.FechaEntrada).Value.Minutes: 0;
                    registro.Importe1 = !_context.Vehiculos.Any(a => a.Placa.ToUpper().Equals(importe.Placa.ToUpper())) ? registro.TiempoTotal * 0.5 : 0;
                    registro.Estado = !_context.Vehiculos.Any(a => a.Placa.ToUpper().Equals(importe.Placa.ToUpper())) ? 3: 2;
                    _context.Importes.Update(registro);
                }
                _context.SaveChanges();

                return new ResultDTO()
                {
                    estado = true,
                    mensaje = importe.Estado == 1 ? "Se ha registrado el ingreso del vehículo con placa: " + importe.Placa : "Se ha registrado la salida del vehículo con placa: " + importe.Placa,
                    Result = importe.Estado == 1 ? importe : registro
                };


            }
            catch (Exception ex)
            {

                return new ResultDTO
                {
                    estado = false,
                    mensaje = ex.Message,
                    Result = null
                };
            }
        }
        public async Task<ResultDTO> GenerarCierre(int mes)
        {
            try
            {
                var registros = _context.Importes.Where(a => a.FechaSalida.Value.Month == mes && a.Estado == 2).ToList();

                if(registros != null) 
                {
                    for(int i = 0; i < registros.Count; i++) 
                    {
                        registros[i].TiempoTotal = (registros[i].FechaSalida - registros[i].FechaEntrada).Value.Minutes;
                        registros[i].Estado = 3;
                    }
                    var placas = (from registro in registros  select registro.Placa).Distinct().ToList();
                    if(placas != null) 
                    {
                        foreach(var placa in placas) 
                        {
                            var registrosPorPlaca = registros.Where(a => a.Placa == placa).ToList();
                            if(_context.Vehiculos.Any(a => a.Placa == placa && a.IdTipoVehiculo == 1)) 
                            {
                                for (int i = 0; i < registrosPorPlaca.Count; i++)
                                {
                                    if(i == 0) 
                                    {
                                        registrosPorPlaca[i].TiempoAcumulado = registrosPorPlaca[i].TiempoTotal;
                                    }
                                    else 
                                    {
                                        registrosPorPlaca[i].TiempoAcumulado = registrosPorPlaca[i-1].TiempoAcumulado = registrosPorPlaca[i].TiempoTotal;
                                        _context.Importes.Update(registrosPorPlaca[i]);
                                    }
                                }
                                registrosPorPlaca[registrosPorPlaca.Count - 1].Importe1 = registrosPorPlaca[registrosPorPlaca.Count - 1].TiempoAcumulado * _context.TiposVehiculos.Where(a => a.IdTipoVehiculo == 1).FirstOrDefault().ImportePorMinuto;
                                _context.Importes.Update(registrosPorPlaca[registrosPorPlaca.Count - 1]);
                            }
                        }
                    }
                  
                }
                var res = _context.SaveChanges();
                return new ResultDTO
                {
                    estado = true,
                    mensaje = "Cierre completo, registros actualizados: " + res,
                    Result = res
                };
            }
            catch (Exception ex)
            {

                return new ResultDTO
                {
                    estado = false,
                    mensaje = ex.Message,
                    Result = null
                };
            }
        }
        public async Task<List<ImportesDTO>> GetImportesPorMes(int mes)
        {
            try
            {
                var importes = _context.Importes.Where(a => a.FechaSalida.Value.Month == mes).ToList();
                return _mapper.Map<List<ImportesDTO>>(importes);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<ImportesDTO> GetImportesPorVehiculo(string placa)
        {
            try
            {
                var importes = _context.Importes.Where(a => a.Placa == placa).ToList();
                return _mapper.Map<ImportesDTO>(importes.Max());
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
