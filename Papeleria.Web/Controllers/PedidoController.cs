using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using Papeleria.LogicaAplicacion.CasosDeUso.Lineas;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;
using Papeleria.LogicaAplicacion.InterfacesCU.Lineas;
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
        private IGetClientesCU _getClientesCU;
        private IFindClienteByIDCU _findClienteByID;
        private ICalcularPrecioLinea _calcularPrecioLinea;
        //private IGetPedidosAscendentes _getPedidosAscendentes;
        
        private static PedidoDTO tempPedido;
        private static List<LineaDTO> _tempListaLineas;
        private static LineaDTO tempLinea;


        public PedidoController(ICrearPedidoCU crearPedidoCU,
            IArticulosOrdenadosAlfabeticamenteCU articulosOrdenados, IFindByIDArticuloCU findByIDArticuloCU, 
            IGetClientesCU getClientesCU, IFindClienteByIDCU findClienteByIDCU,
            ICalcularPrecioLinea calcularPrecioLinea)
            //IGetPedidosAscendentes getPedidosAscendentes)
        {
           
            this._crearPedidoCU = crearPedidoCU;
            this._articulosCU = articulosOrdenados;
            this._findByIDArticuloCU = findByIDArticuloCU;
            this._getClientesCU= getClientesCU;
            this._findClienteByID = findClienteByIDCU;
            this._calcularPrecioLinea = calcularPrecioLinea;

            //this._getPedidosAscendentes = getPedidosAscendentes;
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
            ViewBag.Clientes=_getClientesCU.GetClienteDTOs();
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
            pedidoDTO.cliente = _findClienteByID.EncontrarPorIdCliente(pedidoDTO.clienteId);
            /*tengo que cargarle a pedidodto la lista de lineas*/
            try
            {
                if (tempPedido != null && tempPedido._lineas.Count > 0)
                {
                    pedidoDTO._lineas = tempPedido._lineas;
                }
                foreach (LineaDTO l in tempPedido._lineas)
                {
                    l.precioLinea = _calcularPrecioLinea.CalcularPrecioLinea(l);
                    
                }
                double subTotal = tempPedido._lineas.Sum(linea => linea.precioLinea);
                ViewBag.SubTotal = subTotal;
                _crearPedidoCU.CrearPedido(pedidoDTO);
                tempPedido = null;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                tempPedido = null;
                ViewBag.Clientes = _getClientesCU.GetClienteDTOs();
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
                l.precioLinea = _calcularPrecioLinea.CalcularPrecioLinea(l);
                
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
