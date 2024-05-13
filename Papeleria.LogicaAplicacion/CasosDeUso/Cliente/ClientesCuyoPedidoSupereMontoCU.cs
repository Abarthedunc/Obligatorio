using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Cliente
{
    public class ClientesCuyoPedidoSupereMontoCU : IClientesCuyoPedidoSupereMontoCU
    {
        private IRepositorioCliente _repositorioClientes;
        

        public ClientesCuyoPedidoSupereMontoCU(IRepositorioCliente repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }


        IEnumerable<LogicaNegocio.Entidades.Cliente> IClientesCuyoPedidoSupereMontoCU.ClientesCuyoPedidoSupereMonto(double monto)
        {

            return _repositorioClientes.ClientesCuyoPedidoSupereMonto(monto);
        }
    }
    
    }

