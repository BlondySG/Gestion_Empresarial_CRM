using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TbRolController : Controller
    {
        #region Constructor
        TbRolHelper _tbRolHelper;

        public TbRolController()
        {
            _tbRolHelper = new TbRolHelper();
        }
        #endregion

        #region Read
        // GET: TbRolController
        public ActionResult Index()
        {
            try
            {
                List<TbRolViewModel> roles = _tbRolHelper.GetAll();
                //ViewBag.Title = "Todos los Roles";
                return View(roles);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        // GET: TbRolController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                TbRolViewModel rolViewModel = _tbRolHelper.Details(id);
                return View(rolViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Create
        // GET: TbRolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TbRolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbRolViewModel rol)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbrol", rol);
                response.EnsureSuccessStatusCode();
                TbRolViewModel tbRolViewModel = response.Content.ReadAsAsync<TbRolViewModel>().Result;
                return RedirectToAction("Details", new { id = tbRolViewModel.IdRol });
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

        #region Update
        // GET: TbRolController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TbRolViewModel tbRolViewModel = _tbRolHelper.Edit(id);
                return View(tbRolViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbRolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbRolViewModel rol)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbrol", rol);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Details", new {id = rol.IdRol});
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: TbRolController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TbRolViewModel tbRolViewModel = _tbRolHelper.Delete(id);
                return View(tbRolViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbRolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbRolViewModel rol)
        {
            try
            {
                int id = rol.IdRol;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbrol/" + id.ToString());
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
