using DAL.Interfaces;
using Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class TbRolDALImpl : ITbRolDAL
    {
        private UnidadDeTrabajo<TbRol> unidad;
        GeCrmContext context;

        #region Constructor
        public TbRolDALImpl(GeCrmContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create
        public bool Add(TbRol entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<TbRol>(context))
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

        public void AddRange(IEnumerable<TbRol> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        public IEnumerable<TbRol> Find(Expression<Func<TbRol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #region Read
        public TbRol Get(int id)
        {
            try
            {
                TbRol rol = null;
                using (unidad = new UnidadDeTrabajo<TbRol>(context))
                {
                    rol = unidad.genericDAL.Get(id);
                }
                return rol;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TbRol> GetAll()
        {
            try
            {
                IEnumerable<TbRol> roles = null;
                using (unidad = new UnidadDeTrabajo<TbRol>(context))
                {
                    roles = unidad.genericDAL.GetAll();
                }
                return roles;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public bool Remove(TbRol entity)
        {
            bool result = false;
            try
            {
                using (unidad = new UnidadDeTrabajo<TbRol>(context))
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

        public void RemoveRange(IEnumerable<TbRol> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        public TbRol SingleOrDefault(Expression<Func<TbRol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #region Update
        public bool Update(TbRol entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TbRol> unidad = new UnidadDeTrabajo<TbRol>(context))
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
