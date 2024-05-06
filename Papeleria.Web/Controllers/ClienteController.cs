using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;

namespace Papeleria.Web.Controllers
{
    

    public class ClienteController : Controller
    {
        private IClientesCuyoPedidoSupereMontoCU _clientesCuyoPedidoSupereMontoCU;
        public ClienteController(IClientesCuyoPedidoSupereMontoCU clientesCuyoPedidoSupereMontoCU) 
        {
            _clientesCuyoPedidoSupereMontoCU = clientesCuyoPedidoSupereMontoCU;
        }  
        // GET: ClienteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
        public ActionResult ClientesCuyoPedidoSupereMonto()
        {
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientesCuyoPedidoSupereMonto(double monto) 
        {
            return View(this._clientesCuyoPedidoSupereMontoCU.ClientesCuyoPedidoSupereMonto(monto));
        }
    }
}
