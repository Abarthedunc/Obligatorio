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
        public double descuento { get; set; }
        public EstadoPedido estadoPedido { get; set; }
        public PedidoDTO(int Id, DateTime fecha, ClienteDTO cliente, List<LineaDTO> linea, double precioTotal, double descuento)
        {
            this.id = Id;
            this.fechaPedido= fecha;
            this.cliente = cliente;
            this._lineas = linea;
            this.precioTotal = precioTotal;
            this.descuento = descuento;
            this.estadoPedido = estadoPedido;
        }
    }
}
