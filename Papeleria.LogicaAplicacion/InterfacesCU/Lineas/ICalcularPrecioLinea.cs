using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCU.Lineas
{
    public interface ICalcularPrecioLinea
    {
        public double CalcularPrecioLinea(LineaDTO l);
    }
}
