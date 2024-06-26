﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;
using Papeleria.LogicaAplicacion.InterfacesCU.Clientes;

namespace Papeleria.Web.Controllers
{
    

    public class ClienteController : Controller
    {
        private ICrearClienteCU _crearClienteCU;
        private IClientesCuyoPedidoSupereMontoCU _clientesCuyoPedidoSupereMontoCU;
        private IBuscarEnClientesCU _buscarEnClientesCU;
        private IGetClientesCU _getClientesCU;
        public ClienteController(IClientesCuyoPedidoSupereMontoCU clientesCuyoPedidoSupereMontoCU, ICrearClienteCU crearClienteCU,
            IBuscarEnClientesCU buscarEnClientesCU, IGetClientesCU getClientesCU) 
        {
            _clientesCuyoPedidoSupereMontoCU = clientesCuyoPedidoSupereMontoCU;
            _crearClienteCU = crearClienteCU;
            _buscarEnClientesCU = buscarEnClientesCU;
            _getClientesCU = getClientesCU;
        }  
        // GET: ClienteController
        //todo: el index tiene que ser con clienteDTO
        public ActionResult Index()
        {
            return View(this._getClientesCU.GetClienteDTOs());
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
        public ActionResult Create(ClienteDTO clienteDTO)
        {
            try
            {
                _crearClienteCU.CrearCliente(clienteDTO);
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
        public ActionResult ClientesCuyoPedidoSupereMonto(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientesCuyoPedidoSupereMonto(double monto)
        {
            try
            {
                this._clientesCuyoPedidoSupereMontoCU.ClientesCuyoPedidoSupereMonto(monto);
            }
            catch(Exception ex) 
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
            return View();
        }
        public ActionResult BuscarEnClientes()
        {
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarEnClientes(string criterio) 
        { 
            return View(this._buscarEnClientesCU.BuscarEnClientes(criterio));
        }
        
    }
}
