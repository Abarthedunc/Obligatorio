using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Cliente
{
    public class BuscarClientesPorNombreCU : IGetClientesBusquedaCU
    {
        private IRepositorioCliente _repositorioClientes;

        public BuscarClientesPorNombreCU(IRepositorioCliente repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }
        
        
        
       
        IEnumerable<LogicaNegocio.Entidades.Cliente> IGetClientesBusquedaCU.BuscarClientesPorNombre(string criterio)
        {
            return _repositorioClientes.BuscarClientesPorNombre(criterio);
        }
    }
}
