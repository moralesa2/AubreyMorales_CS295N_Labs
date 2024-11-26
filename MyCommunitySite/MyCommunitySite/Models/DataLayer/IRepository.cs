using Newtonsoft.Json.Bson;

namespace MyCommunitySite.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(QueryOptions<T> options);

        T? Get(int id);
        T? Get(QueryOptions<T> options);

        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        void Save();
    }
}
