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
    public class EmpleadosApp: IEmpleadosApp
    {
        private readonly IEmpleadosSrv _empleado;
        public EmpleadosApp(IEmpleadosSrv empleado) 
        {
            _empleado = empleado;
        }
        public async Task<List<EmpleadosDTO>> GetEmpleados() 
        {
            return await _empleado.GetEmpleados();    
        }
        public async Task<EmpleadosDTO> GetEmpleadosById(string id)
        {
            return await _empleado.GetEmpleadosById(id);
        }
        public async Task<int> CreateEmpleados(EmpleadosDTO empleados)
        {
            return await _empleado.CreateEmpleados(empleados);
        }
        public async Task<int> EditEmpleados(EmpleadosDTO empleados) 
        {
            return await _empleado.EditEmpleados(empleados);
        }
        public async Task<int> DeleteEmpleados(string id)
        {
            return await _empleado.DeleteEmpleados(id);
        }
    }
}
