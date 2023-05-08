using Models.Parqueadero.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Parqueadero.Interfaces
{
    public interface ITipoUsuarioSrv
    {
        Task<List<TiposUsuariosDTO>> GetTiposUsuarios();
        Task<TiposUsuariosDTO> GetTipoUsuarioById(int id);
        Task<int> CreateTipoUsuario(TiposUsuariosDTO tipoUsuario);
        Task<int> EditTipoUsuario(TiposUsuariosDTO tipoUsuario);
        Task<int> DeleteTipoUsuario(int id);
    }
}
