using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.PedidoComun;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPedidoEF : IRepositorioPedido
    {
        private PapeleriaContext _context;
        public RepositorioPedidoEF()
        {
            _context = new PapeleriaContext();
        }

        

        public bool Add(Pedido aAgregar)
        {
            try
            {
                if (aAgregar.EsValido())
                {
                    _context.Pedidos.Add(aAgregar);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (PedidoComunNoValidoException ex)
            {
                throw ex;
            }
        }

        

        public IEnumerable<Pedido> FindAll()
        {
            return _context.Pedidos;
        }

        public Pedido FindByID(int id)
        {
                return _context.Pedidos.Where(pedido => pedido.id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                Pedido aRemover = _context.Pedidos.Where(p => p.id == id)
                    .FirstOrDefault();
                if (aRemover == null)
                {
                    return false;
                }
                _context.Pedidos.Remove(aRemover);
                _context.SaveChanges();
                return true;
            }
            catch (PedidoComunNoValidoException ex)
            {
                throw ex;
            }
        }

        public bool Update(Pedido aModificar)
        {
            try
            {
                aModificar.EsValido();
                _context.Pedidos.Update(aModificar);
                _context.SaveChanges();
                return true;
            }
            catch (PedidoComunNoValidoException ex)
            {
                throw ex;
            }
        }
    }
}
