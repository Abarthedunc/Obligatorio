using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocios.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class PedidoDTO
    {
        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        public ClienteDTO cliente { get; set; }
        public List<LineaDTO> _lineas { get; set; }
        public double precioTotal { get; set; }
        public double iva { get; set; }
        public double descuento { get; set; }
        public EstadoPedido estadoPedido { get; set; }
        public int diasParaLaEntrega { get; set; }
        public PedidoDTO() { }
        public PedidoDTO(Pedido pedido)
        {
            if(pedido != null)
            {
                this.fechaPedido = pedido.fechaPedido;
                this.cliente = new ClienteDTO(pedido.cliente);
                this._lineas = pedido._lineas.Select(linea => new LineaDTO(linea)).ToList();
                this.precioTotal = pedido.precioTotal;
                this.descuento = pedido.descuento;
                this.estadoPedido = pedido.estadoPedido;
                this.iva = pedido.iva;
                this.estadoPedido = pedido.estadoPedido;
                this.diasParaLaEntrega = pedido.diasParaLaEntrega;
            }
            
        }
    }
}
