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
        public List<Linea> _lineas { get; set; }
        public double precioTotal { get; set; }
        public double descuento {  get; set; }
        public Pedido() { }

        public Pedido(DateTime fechaPedido, Cliente cliente)
        {
            //todo: datetime.now
            this.fechaPedido = fechaPedido;
            this.cliente = cliente;
        }

        public bool EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
