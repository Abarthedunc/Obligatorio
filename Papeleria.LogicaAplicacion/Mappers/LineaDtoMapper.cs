using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class LineaDtoMapper
    {
        public static LineaDTO ToDto(Linea linea)
        {
            return new LineaDTO(linea);
        }
    }
}
