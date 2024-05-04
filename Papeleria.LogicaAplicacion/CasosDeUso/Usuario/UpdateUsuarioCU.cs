using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Usuario
{
    public class UpdateUsuarioCU : IUpdateUsuarioCU
    {
        private IRepositorioUsuario _repositorioUsuarios;
        public UpdateUsuarioCU(IRepositorioUsuario repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public void UpdateUsuario(UsuarioDTO dto)
        {
            this._repositorioUsuarios.Update(UsuarioDtoMapper.FromDto(dto));
        }
    }


}
