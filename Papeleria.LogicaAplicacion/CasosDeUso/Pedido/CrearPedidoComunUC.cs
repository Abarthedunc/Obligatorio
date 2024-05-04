using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedido
{
    public class CrearPedidoComunUC : ICrearPedidoComunUC
    {
        private IRepositorioPedidoComun _pedidos;
        public CrearPedidoComunUC(IRepositorioPedidoComun pedidos)
        {
            _pedidos = pedidos;
        }

         void ICrearPedidoComunUC.CrearPedidoComunUC(PedidoComunDTO pedidoACrear)
        {
                _pedidos.Add(PedidoComunDtoMapper.FromDto(pedidoACrear));
        }
    }
}
