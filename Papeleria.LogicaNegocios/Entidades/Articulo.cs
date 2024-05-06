using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Articulo : IValidable<Articulo>
    {
        private IRepositorioArticulo _repoitorioArticulo;
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codProveedor { get; set; }
        public double precioActual { get; set; }
        public int id { get; set; }
        public Articulo() { }
        public Articulo(IRepositorioArticulo repositorioArticulo)
        {
            _repoitorioArticulo = repositorioArticulo;
        }
        public Articulo(string nombre, string descripcion, string codProveedor, double precioActual)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.codProveedor = codProveedor;
            this.precioActual = precioActual;
        }

        public bool EsValido()
        {
            if(ValidarNombre()&&
            ValidarCodProveedor())
            {
                return true;
            }
            else
            {
                return false;
            }
            
            
        }
        public bool ValidarNombre()
        {
            if(this.nombre.Length>9&&this.nombre.Length<199) { return true; }
            return false;
        }
        public bool ValidarCodProveedor()
        {
            int codigo=int.Parse(this.codProveedor);
            //if (codigo < 13 && _repoitorioArticulo.Where( a => a.codProveedor == codigo)) return false;
            
            return true;
        }
    }
}
