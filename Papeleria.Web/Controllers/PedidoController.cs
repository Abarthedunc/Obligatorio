using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;

namespace Papeleria.Web.Controllers
{
    public class PedidoController : Controller
    {
        private ICrearPedidoCU _crearPedidoCU;
        private IArticulosOrdenadosAlfabeticamenteCU _articulosCU;
        private IFindByIDArticuloCU _findByIDArticuloCU;
        
        private static PedidoDTO tempPedido;
        private static List<LineaDTO> _tempListaLineas;
        private static LineaDTO tempLinea;


        public PedidoController(ICrearPedidoCU crearPedidoCU, IArticulosOrdenadosAlfabeticamenteCU articulosOrdenados, IFindByIDArticuloCU findByIDArticuloCU)
        {
           
            this._crearPedidoCU = crearPedidoCU;
            this._articulosCU = articulosOrdenados;
            this._findByIDArticuloCU = findByIDArticuloCU;
        }
        // GET: PedidoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            if (tempPedido != null)
            {
                ViewBag._tempListaLinea = tempPedido._lineas;
            }


            return View();
        }


        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoDTO pedidoDTO)
        {
            
            /*tengo que cargarle a pedidodto la lista de lineas*/
            try
            {
                if (tempPedido != null && tempPedido._lineas.Count > 0)
                {
                    pedidoDTO._lineas = tempPedido._lineas;
                }
                _crearPedidoCU.CrearPedido(pedidoDTO);
                tempPedido = null;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult AgregarArticuloView() 
        {
            ViewBag.Articulos = _articulosCU.GetArticulosOrdenados();
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarArticulo(LineaDTO l)
        {
            try
            {
                l.articulo = _findByIDArticuloCU.EncontrarPorIdArticulo(l.articuloId);
                if(tempPedido==null)
                {
                    tempPedido = new PedidoDTO { _lineas = new List<LineaDTO>()};
                }
                tempPedido._lineas.Add(l);

                return RedirectToAction(nameof(Create));

            }

            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }
        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
