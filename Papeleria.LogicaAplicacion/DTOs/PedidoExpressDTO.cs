using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class PedidoExpressDTO
    {
        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        public Cliente cliente { get; set; }
        public Linea lineas { get; set; }
        public PedidoExpressDTO(DateTime fechaPedido, ClienteDTO cliente, LineaDTO lineas)
        {
        }
        public PedidoExpressDTO(PedidoExpress pedidoExpress)
        {
            if (pedidoExpress != null)
            {
                id = pedidoExpress.id;
                cliente = pedidoExpress.cliente;
                lineas = pedidoExpress.lineas;
                fechaPedido = pedidoExpress.fechaPedido;
            }
        }
        public PedidoExpressDTO() { }
    }
}
