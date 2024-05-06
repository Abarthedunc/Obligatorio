using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Cliente;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioClienteEF : IRepositorioCliente
    {
        private PapeleriaContext _context;
        public RepositorioClienteEF()
        {
            _context = new PapeleriaContext();
        }

        public bool Add(Cliente aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                _context.Clientes.Add(aAgregar);
                _context.SaveChanges();
                return true;
            }
            catch (ClienteNoValidoException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Cliente> FindAll()
        {
            return _context.Clientes;
        }

        public Cliente FindByID(int id)
        {
                return _context.Clientes.Where(cliente => cliente.ID == id).FirstOrDefault();

        }

        public bool Remove(int id)
        {
            try
            {
                Cliente aRemover = _context.Clientes.Where(cliente => cliente.ID == id)
                    .FirstOrDefault();
                if (aRemover == null)
                {
                    return false;
                }
                _context.Clientes.Remove(aRemover);
                _context.SaveChanges();
                return true;
            }
            catch (ClienteNoValidoException ex)
            {
                throw ex;
            }
        }

        public bool Update(Cliente aModificar)
        {
            try
            {
                aModificar.EsValido();
                _context.Clientes.Update(aModificar);
                _context.SaveChanges();
                return true;
            }
            catch (ClienteNoValidoException ex)
            {
                throw ex;
            }
        }
        
        IEnumerable<Cliente> IRepositorioCliente.BuscarClientesPorNombre(string criterio)
        {
            var clienteEncontrado = _context.Clientes.Where(c => c.nombreCompleto.nombre.
            Contains(criterio) || c.nombreCompleto.apellido.Contains(criterio)).ToList();
            return clienteEncontrado;
        }

        //Dado un monto, los clientes que hayan realizado pedidos cuyo total supere el monto dado.
        IEnumerable<Cliente> IRepositorioCliente.ClientesCuyoPedidoSupereMonto(double valor) 
        {
            List<Pedido> _pedidosAux = new List<Pedido>();
            _pedidosAux=_context.Pedidos.Where(p => p.monto > valor).ToList();
            var clienteAux= _pedidosAux.Select(c => c.cliente).ToList();
            return clienteAux;
        }
    }
}
