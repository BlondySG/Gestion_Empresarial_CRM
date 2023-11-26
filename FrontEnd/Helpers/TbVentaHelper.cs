using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbVentaHelper
    {
        #region Get Cliente 
        public TbClienteViewModel GetCliente(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbcliente/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbClienteViewModel clienteViewModel =
                    response.Content.ReadAsAsync<TbClienteViewModel>().Result;
                return clienteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Get List Clientes
        public List<TbClienteViewModel> GetClientes()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/tbcliente/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<TbClienteViewModel> clientes =
                JsonConvert.DeserializeObject<List<TbClienteViewModel>>(content);

            return clientes;
        }
        #endregion

        #region Read
        public List<TbVentaViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbventa");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbVentaViewModel> ventas =
                    JsonConvert.DeserializeObject<List<TbVentaViewModel>>(content);

                return ventas;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Details
        public TbVentaViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbventa/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbVentaViewModel ventaViewModel = response.Content.ReadAsAsync<TbVentaViewModel>().Result;
                ventaViewModel.TbVenta = this.GetVenta(ventaViewModel.IdVenta);

                return ventaViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Update
        public TbVentaViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbventa/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbVentaViewModel tbVentaViewModel = response.Content.ReadAsAsync<TbVentaViewModel>().Result;
                tbVentaViewModel.Ventas = this.GetVentas();

                return tbVentaViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public TbVentaViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbventa/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbVentaViewModel tbVentaViewModel = response.Content.ReadAsAsync<TbVentaViewModel>().Result;
                tbVentaViewModel.TbVenta = this.GetVenta(tbVentaViewModel.IdVenta);

                return tbVentaViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

    }
}
