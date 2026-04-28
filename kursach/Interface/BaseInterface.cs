using kursach.Models;

namespace kursach.Interface;

public interface IRepository<T> : IDisposable where T : class
{
    IEnumerable<T> GetAllList();
    T GetById(int id);
    void Create(T item);
    void Update(T item);
    void Delete(T item);
    void SaveChanges();
}
