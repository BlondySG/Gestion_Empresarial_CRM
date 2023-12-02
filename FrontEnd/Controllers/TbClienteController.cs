using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TbClienteController : Controller
    {
        #region Contructor
        TbClienteHelper _tbClienteHelper;

        public TbClienteController()
        {
            _tbClienteHelper = new TbClienteHelper();  
        }
        #endregion

        #region Create
        // GET: TbClienteController/Create
        public ActionResult Create()
        {
            try
            {
                TbClienteViewModel cliente = new TbClienteViewModel { };

                return View(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbClienteViewModel cliente)
        {
            try
            {
                ServiceRepository serviceobj = new ServiceRepository();
                HttpResponseMessage response = serviceobj.PostResponse("api/tbcliente", cliente);
                response.EnsureSuccessStatusCode();
                TbClienteViewModel tbClienteViewModel = response.Content.ReadAsAsync<TbClienteViewModel>().Result;
                return RedirectToAction("Details", new {id = tbClienteViewModel.IdCliente});
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
        // GET: TbClienteController
        public ActionResult Index()
        {
            try
            {
                List<TbClienteViewModel> clientes = _tbClienteHelper.GetAll();

                return View(clientes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbClienteController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                TbClienteViewModel clienteViewModel = _tbClienteHelper.Details(id);

                return View(clienteViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        // GET: TbClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TbClienteViewModel tbClienteViewModel = _tbClienteHelper.Edit(id);

                return View(tbClienteViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbClienteViewModel cliente)
        {
            try
            {
                ServiceRepository serviceobj = new ServiceRepository();
                HttpResponseMessage response = serviceobj.PutResponse("api/tbcliente", cliente);
                response.EnsureSuccessStatusCode();
                TbClienteViewModel tbClienteViewModel = response.Content.ReadAsAsync<TbClienteViewModel>().Result;
                return RedirectToAction("Details", new {id = tbClienteViewModel.IdCliente});
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: TbClienteController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TbClienteViewModel tbClienteViewModel = _tbClienteHelper.Delete(id);

                return View(tbClienteViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbClienteViewModel cliente)
        {
            try
            {
                int id = cliente.IdCliente;
                ServiceRepository serviceobj = new ServiceRepository();
                HttpResponseMessage response = serviceobj.DeleteResponse("api/tbcliente/" +  id.ToString());
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
