using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Usuario
{
    public class GetUsuariosAscendenteCU : IGetUsuariosAscendenteCU
    { 
        //Inyeccion de dependencia
        private IRepositorioUsuario _repositorioUsuarios;

        public GetUsuariosAscendenteCU(IRepositorioUsuario repositorioUsuarios)
        {
            _repositorioUsuarios = repositorioUsuarios;
        }

        public IEnumerable<LogicaNegocio.Entidades.Usuario> GetUsuariosOrdenados()
        {
            return _repositorioUsuarios.UsuariosOrdenadosNombre();
        }

        
    }
}
