using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Linea : IValidable<Linea>
    {
        public int Id { get; set; }
        [ForeignKey(nameof(articulo))] public int articuloId { get; set; }
        public Articulo articulo { get; set; }
        public int cantUnidades { get; set; }
        public double precioUnitario { get; set; }
        public Linea() { }
        public Linea(Articulo articulo, int cantUnidades, double precioUnitario)
        {
            this.articulo = articulo;
            this.cantUnidades = cantUnidades;
            this.precioUnitario = precioUnitario;
        }

        public void EsValido()
        {
            throw new NotImplementedException();
        }
    }
}
