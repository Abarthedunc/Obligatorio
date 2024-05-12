using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Exceptions.Articulo;
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
        public void EsValido()
        {
            ValidarNombre();
            ValidarCodProveedor();
        }
        public void ValidarNombre()
        {
            if(this.nombre.Length < 9 && this.nombre.Length > 199)
            {
                throw new ArticuloNoValidoException("Verifique el largo de su nombre y que no se repita");
            }
        }
        public void ValidarCodProveedor()
        {
            int codigo=int.Parse(this.codProveedor);
            if (codigo != 13) throw new ArticuloNoValidoException("El codigo de proveedor debe tener 13 digitos");
        }
        //todo:stock mayor que 0
        #endregion
    }
}
