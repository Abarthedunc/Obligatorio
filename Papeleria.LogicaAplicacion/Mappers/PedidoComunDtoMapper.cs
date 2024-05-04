using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class PedidoComunDtoMapper
    {
        public static PedidoComunDTO ToDto(PedidoComun pedidoComun)
        {
            return new PedidoComunDTO(pedidoComun);
        }
        public static PedidoComun FromDto(PedidoComunDTO dto)
        {
            if(dto!= null)
            {
                PedidoComun nuevoPedido = new PedidoComun(dto.fechaPedido, dto.cliente, dto.lineas);
                return nuevoPedido;
            }
            return null;
        }
    }
}
