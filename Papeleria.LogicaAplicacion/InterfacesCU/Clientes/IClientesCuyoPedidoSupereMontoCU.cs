﻿using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Clientes
{
    public interface IClientesCuyoPedidoSupereMontoCU
    {
        public IEnumerable<Cliente> ClientesCuyoPedidoSupereMonto(double monto);

    }
}
