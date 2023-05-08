using Models.Parqueadero.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parqueadero.Interfaces
{
    public interface IEmpleadosApp
    {
        Task<List<EmpleadosDTO>> GetEmpleados();
        Task<EmpleadosDTO> GetEmpleadosById(string id);
        Task<int> CreateEmpleados(EmpleadosDTO empleados);
        Task<int> EditEmpleados(EmpleadosDTO empleados);
        Task<int> DeleteEmpleados(string id);
    }
}
