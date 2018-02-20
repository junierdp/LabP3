using System;
using System.Linq.Expressions;
using INTEC.Data;
using INTEC.Data.Infaestructure;

namespace INTEC.Repository.Framework
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public DataResult Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public DataResult GetAll()
        {
            throw new NotImplementedException();
        }

        public DataResult GetAll(Expression<Func<T, bool>> specification)
        {
            throw new NotImplementedException();
        }

        public DataResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public DataResult SaveChanges()
        {
            throw new NotImplementedException();
        }

        public DataResult Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
