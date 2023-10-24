using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly GeCrmContext context;
        public IDALGeneric<T> genericDAL;

        public UnidadDeTrabajo(GeCrmContext _context)
        {
            context = _context;
            genericDAL = new DALGenericImpl<T>(context);
        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
