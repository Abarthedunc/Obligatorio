using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class PedidoComunDTO
    {
        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        public Cliente cliente { get; set; }
        public Linea lineas { get; set; }
        public PedidoComunDTO(DateTime fechaPedido, ClienteDTO cliente, LineaDTO lineas)
        {
        }
        public PedidoComunDTO() { }
        public PedidoComunDTO(PedidoComun pedidoComun)
        {
            if (pedidoComun != null)
            {
                id = pedidoComun.id;
                cliente = pedidoComun.cliente;
                fechaPedido = pedidoComun.fechaPedido;
            }
        }
    }
}
