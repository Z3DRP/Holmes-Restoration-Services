using System.Collections.Generic;

namespace HolmesServices.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(QueryOptions<T> options);

        T Get(QueryOptions<T> options);
        T Get(int id);
        T Get(string id);
        // pass in a objcect
        T Get(T obj);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);

        void Save();
    }
}
