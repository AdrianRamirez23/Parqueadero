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
    public class EstadosApp: IEstadosApp
    {
        private readonly IEstadosSrv _estado;
        public EstadosApp(IEstadosSrv estado)
        {
            _estado = estado;
        }
        public async Task<List<EstadosDTO>> GetEstados() 
        {
            return await _estado.GetEstados();
        }
        public async Task<EstadosDTO> GetEstadoById(int id) 
        {
            return await _estado.GetEstadoById(id);
        }
        public async Task<int> CreateEstado(EstadosDTO estados) 
        {
            return await _estado.CreateEstado(estados);
        }
        public async Task<int> EditEstados(EstadosDTO estados) 
        {
            return await _estado.EditEstados(estados);
        }
        public async Task<int> DeleteEstado(int id) 
        {
            return await _estado.DeleteEstado(id);
        }
    }
}
