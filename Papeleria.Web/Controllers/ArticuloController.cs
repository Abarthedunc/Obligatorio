﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Articulos;

namespace Papeleria.Web.Controllers
{
    public class ArticuloController : Controller
    {
        private ICrearArticuloCU _crearArticuloCU;
        private IArticulosOrdenadosAlfabeticamenteCU _articulosOrdenadosCU;
    

        public ArticuloController(ICrearArticuloCU crearArticuloCU, IArticulosOrdenadosAlfabeticamenteCU articulosOrdenadosCU)
        {
            _crearArticuloCU = crearArticuloCU;
            _articulosOrdenadosCU = articulosOrdenadosCU;   
        }


        // GET: ArticuloController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ArticuloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloDTO articuloDTO)
        {
            try
            {
                _crearArticuloCU.CrearArticulo(articuloDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticuloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticuloController/Edit/5
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

        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticuloController/Delete/5
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
