using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class LineaDTO
    {
        public int Id { get; set; }
        [ForeignKey(nameof(articulo))] public int articuloId { get; set; }
        public ArticuloDTO articulo { get; set; }
        public int cantUnidades { get; set; }
        public double precioUnitario { get; set; }
        public LineaDTO() { }
        public LineaDTO(ArticuloDTO articulo, int cantUnidades, double precioUnitario)
        {
            this.articulo = articulo;
            this.cantUnidades = cantUnidades;
            this.precioUnitario = precioUnitario;
        }
        public LineaDTO(Linea linea)
        {
            if (linea != null)
            {
                //preguntarle como seria en el caso de ArticuloDTO
                cantUnidades = linea.cantUnidades;
                precioUnitario = linea.precioUnitario;
                articuloId = linea.articuloId;
                Id = linea.Id;
            }
        }
    }
}
