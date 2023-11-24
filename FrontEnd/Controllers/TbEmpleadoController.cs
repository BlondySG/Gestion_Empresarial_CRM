using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TbEmpleadoController : Controller
    {
        
        #region Constructor
        TbEmpleadoHelper _tbEmpleadoHelper;
        TbRolHelper _tbrolHelper;


        public TbEmpleadoController()
        {
            _tbEmpleadoHelper = new TbEmpleadoHelper();
            _tbrolHelper = new TbRolHelper();
        }
        #endregion

        #region Get Rol
        private TbRolViewModel GetRol(int id)
        {
            try
            {
                TbRolViewModel rolViewModel = _tbrolHelper.Details(id);

                return rolViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Get List Roles
        private List<TbRolViewModel> GetRoles()
        {
            List<TbRolViewModel> roles = _tbrolHelper.GetAll();

            return roles;
        }
        #endregion

        #region Create
        // GET: TbEmpleadoController/Create
        public ActionResult Create()
        {
            try
            {
                TbEmpleadoViewModel empleado = new TbEmpleadoViewModel { };
                empleado.Roles = this.GetRoles();

                return View(empleado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbEmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbEmpleadoViewModel empleado)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbempleado", empleado);
                response.EnsureSuccessStatusCode();
                TbEmpleadoViewModel tbEmpleadoViewModel = response.Content.ReadAsAsync<TbEmpleadoViewModel>().Result;
                return RedirectToAction("Details", new { id = tbEmpleadoViewModel.IdEmpleado });
            }
            catch (HttpRequestException)
            {
                return RedirectToAction("Error", "Home");
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        // GET: TbEmpleadoController
        public ActionResult Index()
        {
            try
            {
                List<TbEmpleadoViewModel> empleados = _tbEmpleadoHelper.GetAll();

                foreach (var item in empleados)
                {
                    item.TbRol = _tbrolHelper.Details(item.IdRol);
                }
                return View(empleados);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbEmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                TbEmpleadoViewModel empleadoViewModel = _tbEmpleadoHelper.Details(id);
                return View(empleadoViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        // GET: TbEmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TbEmpleadoViewModel tbEmpleadoViewModel = _tbEmpleadoHelper.Edit(id);
                return View(tbEmpleadoViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbEmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbEmpleadoViewModel empleado)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbempleado", empleado);
                response.EnsureSuccessStatusCode();
                TbEmpleadoViewModel tbEmpleadoViewModel = response.Content.ReadAsAsync<TbEmpleadoViewModel>().Result;
                return RedirectToAction("Details", new { id = tbEmpleadoViewModel.IdEmpleado });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: TbEmpleadoController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TbEmpleadoViewModel tbEmpleadoViewModel = _tbEmpleadoHelper.Delete(id);
                return View(tbEmpleadoViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbEmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbEmpleadoViewModel empleado)
        {
            try
            {
                int id = empleado.IdEmpleado;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbempleado/" + id.ToString());
                response.EnsureSuccessStatusCode();
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
