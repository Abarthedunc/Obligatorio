using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Pedidos;
using Papeleria.LogicaNegocio.InterfacesAccesoDatos;

namespace Papeleria.Web.Controllers
{
    public class PedidoController : Controller
    {
        private ICrearPedidoCU _crearPedidoCU;
        public PedidoController(ICrearPedidoCU crearPedidoCU) 
        {
            this._crearPedidoCU = crearPedidoCU;
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
            return View();
        }
       
        
        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoDTO pedidoDTO)
        {
            try
            {
                _crearPedidoCU.CrearPedido(pedidoDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
