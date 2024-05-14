using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedido
{
    public class AnularPedidoCU
    {
        private IRepositorioPedido _repositorioPedidos;

        public AnularPedidoCU (IRepositorioPedido repositorioPedidos)
        {
            _repositorioPedidos = repositorioPedidos;
        }
        public bool AnularPedido(int pedidoId)
        {
            _repositorioPedidos.AnularPedido(_repositorioPedidos.FindByID(pedidoId));
            return true;
        }
    }
}
