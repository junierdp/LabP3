using System;
using System.Linq.Expressions;
using INTEC.Data;
using INTEC.Data.Infaestructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace INTEC.Repository.Framework
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> dbSet;

        public Repository(ApplicationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("You need to specify the context of your application.");
            }

            this.context = context;
            dbSet = context.Set<T>();
        }

        public DataResult GetAll()
        {
            DataResult result = new DataResult();

            try
            {
                result.Data = dbSet.ToList();
                result.Success = true;

                // SELECT * FROM TABLE
            }
            catch (Exception ex)
            {
                result.LogError(ex);
            }

            return result;
        }

        public DataResult GetAll(Expression<Func<T, bool>> specification)
        {
            DataResult result = new DataResult();

            try
            {
                result.Data = dbSet.Where(specification).ToList();
                result.Success = true;

                // SELECT * FROM TABLE WHERE NAME = Junier
            }
            catch (Exception ex)
            {
                result.LogError(ex);
            }

            return result;
        }

        public DataResult GetById(int id)
        {
            DataResult result = new DataResult();

            try
            {
                result.Data = dbSet.Find(id);
                result.Success = true;

                // SELECT * FROM TABLE WHERE ID = @id
            }
            catch (Exception ex)
            {
                result.LogError(ex);
            }

            return result;
        }

        public DataResult Insert(T entity)
        {
            DataResult result = new DataResult();

            try
            {
                dbSet.Add(entity);
                context.SaveChanges();
                result.Data = entity;
                result.Success = true;

                // INSERT INTO TABLE (ID, USERNAME, PASS) VALUES (1, JUNIER, 123456)
            }
            catch (Exception ex)
            {
                result.LogError(ex);
            }

            return result;
        }

        public DataResult SaveChanges()
        {
            throw new NotImplementedException();
        }

        public DataResult Update(T entity)
        {
            DataResult result = new DataResult();

            try
            {
                context.SaveChanges();

                result.Data = entity;

                result.Success = true;

                // UPDATE TABLE SET USERNAME = 'JUNIER' WHERE ID = @ID
            }
            catch (Exception ex)
            {
                result.LogError(ex);
            }

            return result;
        }

        public DataResult Delete(T entity)
        {
            DataResult result = new DataResult();

            try
            {
                dbSet.Remove(entity);

                context.SaveChanges();

                result.Data = entity;

                result.Success = true;

                // DELETE FROM TABLE WHERE ID = @ID
            }
            catch (Exception ex)
            {
                result.LogError(ex);
            }

            return result;
        }
    }
}
