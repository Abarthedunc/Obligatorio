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
        public double precioLinea { get; set; }
        public Linea() { }
        public Linea(Articulo articulo, int cantUnidades)
        {
            this.articulo = articulo;
            this.cantUnidades = cantUnidades;
            this.precioLinea = 0;
        }

        public bool EsValido()
        {
            if (ValidarStock())
            {
                return true;
            }
            return false;
            
        }
        public bool ValidarStock()
        {
            //validar que para articulo de las lineas haya un stock mayor a 0
            int stock = this.articulo.stock;
            if (stock > 0 && cantUnidades>stock)
            {
                return true;
            }
            return false;

        }
        public void CalcularPrecio() 
        {
            precioLinea = articulo.precioActual * cantUnidades;
            
            
        }
    }
}
