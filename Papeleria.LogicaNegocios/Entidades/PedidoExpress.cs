using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocios.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class PedidoExpress : Pedido
    {
        public PedidoExpress() { }
        public PedidoExpress(Cliente cliente, List<Linea> _lineas, double descuento, int dias, double iva) : base(cliente, _lineas, descuento, dias, iva)
         {
         }

        public override void EsValido()
        {
            throw new NotImplementedException();
        }
        public override void CalcularPrecio()
        {
            double precioLineasSumado = 0;

            foreach (Linea l in _lineas)
            {
                precioLineasSumado += l.precioLinea;
            }
            
            precioTotal = precioLineasSumado * iva;

        }
    }
}
