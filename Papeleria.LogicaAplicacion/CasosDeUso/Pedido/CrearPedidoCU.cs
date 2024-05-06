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
    public class CrearPedidoCU : ICrearPedidoCU
    {
        private IRepositorioPedido _pedidos;
        public CrearPedidoCU(IRepositorioPedido pedidos)
        {
            _pedidos = pedidos;
        }

        public void CrearPedidoUC(PedidoComunDTO pedidoACrear)
        {
            throw new NotImplementedException();
        }

        void ICrearPedidoCU.CrearPedidoUC(PedidoComunDTO pedidoACrear)
        {
            _pedidos.Add(PedidoComunDtoMapper.FromDto(pedidoACrear));
        }
    }
}
