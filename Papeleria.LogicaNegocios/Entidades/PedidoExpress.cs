using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class PedidoExpress : Pedido, IValidable<PedidoExpress>
    {
        public PedidoExpress() { }
        public PedidoExpress(DateTime fechaPedido, Cliente cliente, Linea lineas) : base(fechaPedido, cliente, lineas)
        {
        }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
