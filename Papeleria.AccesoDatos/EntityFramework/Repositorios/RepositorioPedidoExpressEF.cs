using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.PedidoExpress;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPedidoExpressEF : IRepositorioPedidoExpress
    {
        private PapeleriaContext _context;
        public RepositorioPedidoExpressEF()
        {
            _context = new PapeleriaContext();
        }
        public bool Add(PedidoExpress aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                _context.PedidosExpress.Add(aAgregar);
                _context.SaveChanges();
                return true;
            }
            catch (PedidoExpressNoValidoException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PedidoExpress> FindAll()
        {
            return _context.PedidosExpress;
        }

        public PedidoExpress FindByID(int id)
        {
                return _context.PedidosExpress.Where(pE => pE.id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                PedidoExpress aRemover = _context.PedidosExpress.Where(pE => pE.id == id)
                    .FirstOrDefault();
                if (aRemover == null)
                {
                    return false;
                }
                _context.PedidosExpress.Remove(aRemover);
                _context.SaveChanges();
                return true;
            }
            catch (PedidoExpressNoValidoException ex)
            {
                throw ex;
            }
        }

        public bool Update(PedidoExpress aModificar)
        {
            try
            {
                aModificar.EsValido();
                _context.PedidosExpress.Update(aModificar);
                _context.SaveChanges();
                return true;
            }
            catch (PedidoExpressNoValidoException ex)
            {
                throw ex;
            }
        }
    }
}
