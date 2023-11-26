using DAL.Interfaces;
using Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class TbVentaDALImpl : ITbVentaDAL
    {
        private UnidadDeTrabajo<TbVenta> unidad;
        GeCrmContext context;

        #region Constructor
        public TbVentaDALImpl(GeCrmContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create
        public bool Add(TbVenta entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<TbVenta>(context))
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

        public void AddRange(IEnumerable<TbVenta> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        public IEnumerable<TbVenta> Find(Expression<Func<TbVenta, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #region Read
        public TbVenta Get(int id)
        {
            try
            {
                TbVenta venta = null;
                using (unidad = new UnidadDeTrabajo<TbVenta>(context))
                {
                    venta = unidad.genericDAL.Get(id);
                }
                return venta;
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public IEnumerable<TbVenta> GetAll()
        {
            try
            {
                IEnumerable<TbVenta> ventas = null;
                using (unidad = new UnidadDeTrabajo<TbVenta>(context))
                {
                    ventas = unidad.genericDAL.GetAll();
                }
                return ventas;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public bool Remove(TbVenta entity)
        {
            bool result = false;
            try
            {
                using ( unidad = new UnidadDeTrabajo<TbVenta>(context))
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

        public void RemoveRange(IEnumerable<TbVenta> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        public TbVenta SingleOrDefault(Expression<Func<TbVenta, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #region Update
        public bool Update(TbVenta entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TbVenta> unidad = new UnidadDeTrabajo<TbVenta>(context))
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
