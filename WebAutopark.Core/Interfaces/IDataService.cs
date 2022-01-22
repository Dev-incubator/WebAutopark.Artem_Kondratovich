using System.Collections.Generic;

namespace WebAutopark.Core.Interfaces
{
    public interface IDataService<T>
        where T : class
    {
        IEnumerable<T> GetAllItems();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
