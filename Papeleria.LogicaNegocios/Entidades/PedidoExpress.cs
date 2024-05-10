using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocios.Enumerados;
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
        public PedidoExpress(DateTime fechaPedido,Linea linea, Cliente cliente, Linea lineas, double precioTotal, double descuento, EstadoPedido estadoPedido) : base(fechaPedido, cliente)
        {
        }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
