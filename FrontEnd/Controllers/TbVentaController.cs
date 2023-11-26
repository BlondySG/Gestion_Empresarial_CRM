using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class TbVentaController : Controller
    {
        
        #region Constructor
        TbVentaHelper _tbVentaHelper;
        TbClienteHelper _tbclienteHelper;


        public TbVentaController()
        {
            _tbVentaHelper = new TbVentaHelper();
            _tbclienteHelper = new TbClienteHelper();
        }
        #endregion

        #region Get Cliente
        private TbClienteViewModel GetCliente(int id)
        {
            try
            {
                TbClienteViewModel clienteViewModel = _tbclienteHelper.Details(id);

                return clienteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Get List Clientes
        private List<TbClienteViewModel> GetClientes()
        {
            List<TbClienteViewModel> clientes = _tbclienteHelper.GetAll();

            return cliente;
        }
        #endregion

        #region Create
        // GET: TbVentaController/Create
        public ActionResult Create()
        {
            try
            {
                TbVentaViewModel venta = new TbVentaViewModel { };
                venta.Clientes = this.GetClientes();

                return View(venta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbVentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbVentaViewModel venta)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbventa", venta);
                response.EnsureSuccessStatusCode();
                TbVentaViewModel tbVentaViewModel = response.Content.ReadAsAsync<TbVentaViewModel>().Result;
                return RedirectToAction("Details", new { id = tbVentaViewModel.IdVenta });
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
        // GET: TbVentaController
        public ActionResult Index()
        {
            try
            {
                List<TbVentaViewModel> ventas = _tbVentaHelper.GetAll();

                foreach (var item in ventas)
                {
                    item.TbCliente = _tbclienteHelper.Details(item.IdCliente);
                }
                return View(ventas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbVentaController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                TbVentaViewModel ventaViewModel = _tbVentaHelper.Details(id);
                return View(ventaViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        // GET: TbVentaController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TbVentaViewModel tbVentaViewModel = _tbVentaHelper.Edit(id);
                return View(tbVentaViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbVentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbVentaViewModel venta)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbventa", venta);
                response.EnsureSuccessStatusCode();
                TbVentaViewModel tbVentaViewModel = response.Content.ReadAsAsync<TbVentaViewModel>().Result;
                return RedirectToAction("Details", new { id = tbVentaViewModel.IdVenta });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: TbVentaController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TbVentaViewModel tbVentaViewModel = _tbVentaHelper.Delete(id);
                return View(tbVentaViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbVentaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbVentaViewModel venta)
        {
            try
            {
                int id = venta.IdVenta;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbventa/" + id.ToString());
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
