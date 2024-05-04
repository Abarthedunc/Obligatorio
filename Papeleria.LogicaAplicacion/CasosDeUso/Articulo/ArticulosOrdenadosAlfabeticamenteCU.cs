using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Articulo
{
    public class ArticulosOrdenadosAlfabeticamenteCU : IArticulosOrdenadosAlfabeticamenteCU
    {
        private IRepositorioArticulo _repositorioArticulo;

        public ArticulosOrdenadosAlfabeticamenteCU(IRepositorioArticulo repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public IEnumerable<LogicaNegocio.Entidades.Articulo> GetArticulosOrdenados()
        {
            return _repositorioArticulo.GetArticulosOrdenadosAlfabeticamente();
        }

    }
}
