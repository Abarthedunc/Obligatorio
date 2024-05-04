using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public abstract class Pedido : IValidable<Pedido>
    {
        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        public Cliente cliente { get; set; }
        public Linea lineas { get; set; }
        public Pedido(DateTime fechaPedido, Cliente cliente, Linea lineas)
        {
            this.fechaPedido = fechaPedido;
            this.cliente = cliente;
            this.lineas = lineas;
        }
        public Pedido() { }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
