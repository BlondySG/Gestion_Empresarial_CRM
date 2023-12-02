using DAL.Interfaces;
using Entities;
using System.Linq.Expressions;

namespace DAL.Implementations
{
    public class TbClienteDALImpl : ITbClienteDAL
    {
        private UnidadDeTrabajo<TbCliente> unidad;
        GeCrmContext context;

        #region Constructor
        public TbClienteDALImpl(GeCrmContext context)
        {
            this.context = context;
        }
        #endregion

        #region Create
        public bool Add(TbCliente entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<TbCliente>(context))
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

        public void AddRange(IEnumerable<TbCliente> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        public IEnumerable<TbCliente> Find(Expression<Func<TbCliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #region Read
        public TbCliente Get(int id)
        {
            try
            {
                TbCliente cliente = null;
                using (unidad = new UnidadDeTrabajo<TbCliente>(context))
                {
                    cliente = unidad.genericDAL.Get(id);
                }
                return cliente;
            }
            catch (Exception)
            {
                throw;
            } 
        }

        public IEnumerable<TbCliente> GetAll()
        {
            try
            {
                IEnumerable<TbCliente> clientes = null;
                using (unidad = new UnidadDeTrabajo<TbCliente>(context))
                {
                    clientes = unidad.genericDAL.GetAll();
                }
                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public bool Remove(TbCliente entity)
        {
            bool result = false;
            try
            {
                using ( unidad = new UnidadDeTrabajo<TbCliente>(context))
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

        public void RemoveRange(IEnumerable<TbCliente> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

        public TbCliente SingleOrDefault(Expression<Func<TbCliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #region Update
        public bool Update(TbCliente entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TbCliente> unidad = new UnidadDeTrabajo<TbCliente>(context))
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
