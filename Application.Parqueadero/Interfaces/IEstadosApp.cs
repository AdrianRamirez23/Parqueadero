using Models.Parqueadero.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parqueadero.Interfaces
{
    public interface IEstadosApp
    {
        Task<List<EstadosDTO>> GetEstados();
        Task<EstadosDTO> GetEstadoById(int id);
        Task<int> CreateEstado(EstadosDTO estados);
        Task<int> EditEstados(EstadosDTO estados);
        Task<int> DeleteEstado(int id);
    }
}
