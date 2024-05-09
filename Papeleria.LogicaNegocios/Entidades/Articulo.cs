using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
        [Index(nameof(nombre), IsUnique = true)]
        [Index(nameof(codProveedor), IsUnique = true)]
    public class Articulo : IValidable<Articulo>
    {
        private IRepositorioArticulo _repoitorioArticulo;
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string codProveedor { get; set; }
        public double precioActual { get; set; }
        public int stock {  get; set; }
        public int id { get; set; }
        public Articulo() { }
        public Articulo(IRepositorioArticulo repositorioArticulo)
        {
            _repoitorioArticulo = repositorioArticulo;
        }
        public Articulo(string nombre, string descripcion, string codProveedor, double precioActual, int stock)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.codProveedor = codProveedor;
            this.precioActual = precioActual;
            this.stock = stock;
        }

        #region validaciones
        public bool EsValido()
        {
            if(ValidarNombre()&&
            ValidarCodProveedor()
            )
            {
                return true;
            }
            else return false;


        }
        public bool ValidarNombre()
        {
            if(this.nombre.Length>9&&this.nombre.Length<199) { return true; }
            return false;
        }
        public bool ValidarCodProveedor()
        {
            int codigo=int.Parse(this.codProveedor);
            if (codigo < 13) return false;
            
            return true;
        }
        //todo:stock mayor que 0
        #endregion
    }
}
