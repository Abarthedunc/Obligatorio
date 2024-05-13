using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Lineas;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Lineas
{
    public class CalcularPrecioLinea : ICalcularPrecioLinea
    {
        double ICalcularPrecioLinea.CalcularPrecioLinea(LineaDTO l)
        {
            Linea nuevaLinea = LineaDtoMapper.FromDto(l);
            return nuevaLinea.CalcularPrecio();
        }
    }
}
