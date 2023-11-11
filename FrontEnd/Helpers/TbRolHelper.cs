using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbRolHelper
    {
        #region Read
        public List<TbRolViewModel>GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbrol");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbRolViewModel> rol = 
                    JsonConvert.DeserializeObject<List<TbRolViewModel>>(content);

                return rol;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Details
        public TbRolViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbrol/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbRolViewModel tbRolViewModel = response.Content.ReadAsAsync<TbRolViewModel>().Result;

                return tbRolViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        public TbRolViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbrol/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbRolViewModel tbRolViewModel = response.Content.ReadAsAsync<TbRolViewModel>().Result;

                return tbRolViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public TbRolViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbrol/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbRolViewModel tbRolViewModel = response.Content.ReadAsAsync<TbRolViewModel>().Result;

                return tbRolViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
