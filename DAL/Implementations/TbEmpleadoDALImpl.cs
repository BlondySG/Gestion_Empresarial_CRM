using DAL.Interfaces;
using Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class TbEmpleadoDALImpl : ITbEmpleadoDAL
    {
        private UnidadDeTrabajo<TbEmpleado> unidad;
        GeCrmContext context;

        #region Constructor
        public TbEmpleadoDALImpl(GeCrmContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create
        public bool Add(TbEmpleado entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<TbEmpleado>(context))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<TbEmpleado> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        public IEnumerable<TbEmpleado> Find(Expression<Func<TbEmpleado, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #region Read
        public TbEmpleado Get(int id)
        {
            try
            {
                TbEmpleado empleado = null;
                using (unidad = new UnidadDeTrabajo<TbEmpleado>(context))
                {
                    empleado = unidad.genericDAL.Get(id);
                }
                return empleado;
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public IEnumerable<TbEmpleado> GetAll()
        {
            try
            {
                IEnumerable<TbEmpleado> empleados = null;
                using (unidad = new UnidadDeTrabajo<TbEmpleado>(context))
                {
                    empleados = unidad.genericDAL.GetAll();
                }
                return empleados;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public bool Remove(TbEmpleado entity)
        {
            bool result = false;
            try
            {
                using ( unidad = new UnidadDeTrabajo<TbEmpleado>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }

        public void RemoveRange(IEnumerable<TbEmpleado> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        public TbEmpleado SingleOrDefault(Expression<Func<TbEmpleado, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #region Update
        public bool Update(TbEmpleado entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TbEmpleado> unidad = new UnidadDeTrabajo<TbEmpleado>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }
        #endregion
    }
}
