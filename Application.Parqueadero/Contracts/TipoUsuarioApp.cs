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
    public class TipoUsuarioApp: ITipoUsuarioApp
    {
        private ITipoUsuarioSrv _tipoUsuario;
        public TipoUsuarioApp(ITipoUsuarioSrv tipoUsuario)
        {
            _tipoUsuario = tipoUsuario;
        }
        public async Task<List<TiposUsuariosDTO>> GetTiposUsuarios() 
        {
            return await _tipoUsuario.GetTiposUsuarios();
        }
        public async Task<TiposUsuariosDTO> GetTipoUsuarioById(int id) 
        {
            return await _tipoUsuario.GetTipoUsuarioById(id);
        }
        public async Task<int> CreateTipoUsuario(TiposUsuariosDTO tipoUsuario) 
        {
            return await _tipoUsuario.CreateTipoUsuario(tipoUsuario);
        }
        public async Task<int> EditTipoUsuario(TiposUsuariosDTO tipoUsuario)
        {
            return await _tipoUsuario.EditTipoUsuario(tipoUsuario);
        }
        public async Task<int> DeleteTipoUsuario(int id)
        {
            return await _tipoUsuario.DeleteTipoUsuario(id);
        }
    }
}
