using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU
{
    public interface IGetPedidosAnuladosCU
    {
        public IEnumerable<PedidoDTO> GetPedidosAnulados();

    }
}
