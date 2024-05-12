using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocios.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class PedidoComun : Pedido, IValidable<PedidoComun>
    {
        private IRepositorioPedido _repositorioPedido;
        public PedidoComun() { }
        public PedidoComun(Cliente cliente, List<Linea> _lineas, double descuento, int dias, double iva) : base(cliente, _lineas, descuento, dias, iva)
        {
        }
        public PedidoComun(IRepositorioPedido repositorioPedido)
        {
            this._repositorioPedido = repositorioPedido;
        }

        public void EsValido()
        {
            ValidarCliente();
            
        }
        
        public bool ValidarCliente()
        {
            bool encontrado = false;
            return encontrado;
        }
        public override void CalcularPrecio()
        {
            double subTotal = 0;
            double recargoPorDistancia = 0.05;
           
            foreach(Linea l in _lineas)
            {
                subTotal += l.precioLinea;
            }
            /*if(Cliente.distancia>100)
             si la distancia del cliente es mayor a cien cobrar 
             */
            if (this.cliente.distancia > 100)
            {
                subTotal = subTotal * recargoPorDistancia;
            }
            /*desceunto*/
            double descuentoReal = subTotal * (descuento / 100);
            /*iva*/
            precioTotal = subTotal* (1 + iva / 100)-descuentoReal;

        }
    }
}
