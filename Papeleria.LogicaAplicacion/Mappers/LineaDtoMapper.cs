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
        public static Linea FromDto(LineaDTO linea)
        {
            if(linea!=null)
            {
                ArticuloDTO art = linea.articulo;
                Articulo nuevoArt = ArticuloDtoMapper.FromDto(art);
                Linea nuevaLinea = new Linea(nuevoArt, linea.cantUnidades);
                return nuevaLinea;
            }
            return null;
        }
    }
}
