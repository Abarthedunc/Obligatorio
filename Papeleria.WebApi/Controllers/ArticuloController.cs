using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;

namespace Papeleria.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticuloController : ControllerBase
    {


        private IArticulosOrdenadosAlfabeticamenteCU _artOrdenadosUC;

        public ArticuloController(IArticulosOrdenadosAlfabeticamenteCU artOrdenadosUC)
        {
            _artOrdenadosUC = artOrdenadosUC;
        }

        [HttpGet(Name = "GetArticulosOrdenados")]
        public IEnumerable<ArticuloDTO> Get()
        {
            return this._artOrdenadosUC.GetArticulosOrdenados().ToList();
        }
    }
}
