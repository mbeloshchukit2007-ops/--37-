using System.Collections.Generic;

namespace PostLogisticsApp
{
    // Інтерфейс репозиторію для об'єктів ієрархії Model
    public interface IRepository<T> where T : Model
    {
        void Add(T entity);
        T GetById(int id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(int id);
    }
}
