using Papeleria.LogicaNegocio.InterfacesEntidades;
using Papeleria.LogicaNegocios.Enumerados;
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
        public double iva {  get; set; }
        public double descuento {  get; set; }
        public EstadoPedido estadoPedido { get; set; }
        public int diasParaLaEntrega { get; set; }
        public Pedido() { }

        
        public Pedido(Cliente cliente, List<Linea> _lineas, double descuento, int dias, double iva) { 
            //todo: datetime.now
            this.fechaPedido = DateTime.Now;
            this.cliente = cliente;
            this._lineas = _lineas;
            this.descuento = descuento;
            this.estadoPedido = EstadoPedido.Pendiente;
            this.diasParaLaEntrega = dias;
            this.iva = iva;
            this.precioTotal= 0;

        }

        
        public bool EsValido()
        {
            throw new NotImplementedException();
        }
        public virtual void CalcularPrecio() 
        { 
            throw new NotImplementedException();
        }
    }
}
