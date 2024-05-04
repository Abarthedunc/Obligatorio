using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Exceptions.Linea;
using Papeleria.LogicaNegocio.Exceptions.PedidoComun;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPedidoComunEF : IRepositorioPedidoComun
    {
        private PapeleriaContext _context;
        public RepositorioPedidoComunEF()
        {
            _context = new PapeleriaContext();
        }

        public bool Add(PedidoComun aAgregar)
        {
            try
            {
                aAgregar.EsValido();
                _context.PedidosComunes.Add(aAgregar);
                _context.SaveChanges();
                return true;
            }
            catch (PedidoComunNoValidoException ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PedidoComun> FindAll()
        {
            return _context.PedidosComunes;
        }

        public PedidoComun FindByID(int id)
        {
                return _context.PedidosComunes.Where(pC => pC.id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                PedidoComun aRemover = _context.PedidosComunes.Where(pC => pC.id == id)
                    .FirstOrDefault();
                if (aRemover == null)
                {
                    return false;
                }
                _context.PedidosComunes.Remove(aRemover);
                _context.SaveChanges();
                return true;
            }
            catch (PedidoComunNoValidoException ex)
            {
                throw ex;
            }
        }

        public bool Update(PedidoComun aModificar)
        {
            try
            {
                aModificar.EsValido();
                _context.PedidosComunes.Update(aModificar);
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
