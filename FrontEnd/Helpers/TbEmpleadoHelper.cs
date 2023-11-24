using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbEmpleadoHelper
    {
        #region Get Rol 
        public TbRolViewModel GetRol(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbrol/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbRolViewModel rolViewModel =
                    response.Content.ReadAsAsync<TbRolViewModel>().Result;
                return rolViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Get List Roles
        public List<TbRolViewModel> GetRoles()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/tbrol/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<TbRolViewModel> roles =
                JsonConvert.DeserializeObject<List<TbRolViewModel>>(content);

            return roles;
        }
        #endregion

        #region Read
        public List<TbEmpleadoViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbempleado");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbEmpleadoViewModel> empleados =
                    JsonConvert.DeserializeObject<List<TbEmpleadoViewModel>>(content);

                return empleados;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Details
        public TbEmpleadoViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbempleado/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbEmpleadoViewModel empleadoViewModel = response.Content.ReadAsAsync<TbEmpleadoViewModel>().Result;
                empleadoViewModel.TbRol = this.GetRol(empleadoViewModel.IdRol);

                return empleadoViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Update
        public TbEmpleadoViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbempleado/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbEmpleadoViewModel tbEmpleadoViewModel = response.Content.ReadAsAsync<TbEmpleadoViewModel>().Result;
                tbEmpleadoViewModel.Roles = this.GetRoles();

                return tbEmpleadoViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public TbEmpleadoViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbempleado/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbEmpleadoViewModel tbEmpleadoViewModel = response.Content.ReadAsAsync<TbEmpleadoViewModel>().Result;
                tbEmpleadoViewModel.TbRol = this.GetRol(tbEmpleadoViewModel.IdRol);

                return tbEmpleadoViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

    }
}
