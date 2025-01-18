using Microsoft.EntityFrameworkCore;

namespace MyCommunitySite.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext context { get; set; }
        private DbSet<T> dbSet { get; set; }

        public Repository(ApplicationDbContext ctx)
        {
            context = ctx;
            dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = dbSet;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            if (options.HasOrderBy)
            {
                if (options.HasThenOrderBy)
                {
                    query = query.OrderBy(options.OrderBy).ThenBy(options.OrderBy);
                }
                else
                {
                    query = query.OrderBy(options.OrderBy);
                }
            }
            return query.ToList();
        }

        // TODO: Add get for string Ids
        public virtual T? Get(int id) => dbSet.Find(id);

        public virtual T? Get(QueryOptions<T> options)
        {
            IQueryable<T> query = dbSet;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            return query.FirstOrDefault();
        }

        public virtual void Insert(T entity) => dbSet.Add(entity);
        public virtual void Update(T entity) => dbSet.Update(entity);
        // TODO: Add Delete for string Ids
        public void Delete(int id) => dbSet.Remove(Get(id));
        public virtual void Delete(T entity) => dbSet.Remove(entity);
        public virtual void Save() => context.SaveChanges();
    }
}
