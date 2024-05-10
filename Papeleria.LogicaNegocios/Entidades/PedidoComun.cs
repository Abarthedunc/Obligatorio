using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocios.Enumerados;
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
        public PedidoComun(DateTime fechaPedido,Linea linea, Cliente cliente, double precioTotal, double descuento, EstadoPedido estadoPedido) : base(fechaPedido, cliente)
        {
        }

        public bool EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
