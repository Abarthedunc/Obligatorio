using Microsoft.AspNetCore.Mvc;
using Papeleria.BusinessLogic.ValueObjects;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCU.Usuarios;

namespace Papeleria.Web.Controllers
{
    public class UsuarioController : Controller
    {
        #region ___________CASOS DE USO_____________________
        //el controller no debe tener acceso al repositorio
        //hay que suplantarlo por los casos de uso
        private IGetUsuariosAscendenteCU _ordenarAscendente;
        private ICrearUsuarioCU _crearUsuarioCU;
        private IDeleteUsuarioCU _deleteUsuarioCU;
        private IRecibeIdDevuelveUsuarioCU _recibeIdDevuelveUsuarioCU;
        private IUpdateUsuarioCU _updateUsuarioCU;
        private ILoginUsuarioCU _loginUsuarioCU;
        private IDetailsUsuarioCU _detailsUsuarioCU;
        

        public UsuarioController(IGetUsuariosAscendenteCU ordenarAscendenteCU, ICrearUsuarioCU crearUsuarioCU, IDeleteUsuarioCU deleteUsuarioCU, IRecibeIdDevuelveUsuarioCU recibeIdDevuelveUsuarioCU, IUpdateUsuarioCU updateUsuarioCU, ILoginUsuarioCU loginUsuarioCU, IDetailsUsuarioCU detailsUsuarioCU)
        {
            this._ordenarAscendente = ordenarAscendenteCU;
            this._crearUsuarioCU = crearUsuarioCU;
            this._deleteUsuarioCU = deleteUsuarioCU;
            this._recibeIdDevuelveUsuarioCU = recibeIdDevuelveUsuarioCU;
            this._updateUsuarioCU = updateUsuarioCU;
            this._loginUsuarioCU = loginUsuarioCU;
            this._detailsUsuarioCU = detailsUsuarioCU;


        }
        #endregion

        #region LOGIN Y LOGOUT
        public ActionResult Login() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string contrasenia)
        {
            try
            {
                UsuarioDTO u = _loginUsuarioCU.LoginUsuario(correo, contrasenia);

                HttpContext.Session.SetInt32("LogueadoId", u.Id);
                HttpContext.Session.SetString("LogueadoCorreo", u.email);

                return RedirectToAction("Index", "Home");
            }
            
            catch
            {
                Exception ex;
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public IActionResult Logout()
        {
            try
            {
                
                HttpContext.Session.Clear();

                return RedirectToAction("Index", "Home");
            }

            catch
            {
                Exception ex;
                return RedirectToAction("Index", "Home");
            }
        }


        #endregion 


        #region INDEX

        // GET: UsuarioController
        public ActionResult Index()
        {
            return View(this._ordenarAscendente.GetUsuariosOrdenados());
        }
        #endregion


        #region DETAILS
        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(this._detailsUsuarioCU.DetailsUsuario(id));
            }catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));

            }
        }

        #endregion


        #region CREATE
        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioDTO usuarioDTO)
        {
            try
            {
                _crearUsuarioCU.CrearUsuario(usuarioDTO);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        #endregion


        #region DELETE
        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_recibeIdDevuelveUsuarioCU.RecibeIdDevuelveUsuario(id));
        }
        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsuarioDTO user)
        {
            try
            {
                UsuarioDTO u = _recibeIdDevuelveUsuarioCU.RecibeIdDevuelveUsuario(id);
                this._deleteUsuarioCU.DeleteUsuario(u);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion


        #region EDIT
        public ActionResult Edit(int id)
        {
            return View(_recibeIdDevuelveUsuarioCU.RecibeIdDevuelveUsuario(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsuarioDTO aEditar, string nombre, string apellido)
        {
            try
            {
                var u = new NombreCompletoClientes(nombre, apellido);
                aEditar.nombre=u.nombre;
                aEditar.apellido=u.apellido;
                _updateUsuarioCU.UpdateUsuario(aEditar);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        #endregion


    }
}
