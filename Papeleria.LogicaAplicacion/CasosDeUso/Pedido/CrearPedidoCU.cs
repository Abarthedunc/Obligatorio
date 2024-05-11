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
        private IRepositorioPedido _repositorioPedidos;
        public CrearPedidoCU(IRepositorioPedido repositorioPedidos)
        {
            _repositorioPedidos=repositorioPedidos;
        }

        public void CrearPedido(PedidoDTO dto)
        {
            if (dto.diasParaLaEntrega < 5)
            {
                _repositorioPedidos.Add(PedidoDtoMapper.ToPedidoExpress(dto));
            }
            else
            {
                _repositorioPedidos.Add(PedidoDtoMapper.ToPedidoComun(dto));

            }
        }

        
    }
}
