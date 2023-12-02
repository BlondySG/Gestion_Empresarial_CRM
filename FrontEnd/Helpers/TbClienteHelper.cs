using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbClienteHelper
    {
        #region Read
        public List<TbClienteViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbcliente");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbClienteViewModel> clientes =
                    JsonConvert.DeserializeObject<List<TbClienteViewModel>>(content);

                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Details
        public TbClienteViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbcliente/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbClienteViewModel clienteViewModel = response.Content.ReadAsAsync<TbClienteViewModel>().Result;

                return clienteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public TbClienteViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbcliente/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbClienteViewModel tbClienteViewModel = response.Content.ReadAsAsync<TbClienteViewModel>().Result;

                return tbClienteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public TbClienteViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbcliente/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbClienteViewModel tbClienteViewModel = response.Content.ReadAsAsync<TbClienteViewModel>().Result;

                return tbClienteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
