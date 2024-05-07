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
    public class BuscarEnClientesCU : IBuscarEnClientesCU
    {
        private IRepositorioCliente _repositorioClientes;

        public BuscarEnClientesCU(IRepositorioCliente repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }
        
        
        
       
        IEnumerable<LogicaNegocio.Entidades.Cliente> IBuscarEnClientesCU.BuscarEnClientes(string criterio)
        {
            return _repositorioClientes.BuscarEnClientes(criterio);
        }
    }
}
