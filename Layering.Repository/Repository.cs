using Layering.Data;
using System;
using System.Linq;

namespace Layering.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly UniversityDbContext UniversityDbContext;

        public Repository(UniversityDbContext universityDbContext)
        {
            UniversityDbContext = universityDbContext;
        }

        public void Add(T entity)
        {
            UniversityDbContext.Set<T>().Add(entity);

            UniversityDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            UniversityDbContext.Set<T>().Remove(entity);

            UniversityDbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return UniversityDbContext.Set<T>();
        }

        public abstract T GetOne(int id);

        public void Update(T entity)
        {
            UniversityDbContext.Set<T>().Attach(entity);

            UniversityDbContext.SaveChanges();
        }
    }
}
