using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class PedidoComun : Pedido, IValidable<PedidoComun>
    {
        public PedidoComun() { }
        public PedidoComun(DateTime fechaPedido, Cliente cliente, Linea lineas) : base(fechaPedido, cliente, lineas)
        {
        }

        public bool EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
