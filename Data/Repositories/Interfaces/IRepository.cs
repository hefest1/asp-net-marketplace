using Data.Entities;

namespace Data.Repositories.Interfaces;

public interface IRepository<T> where T : Entity
{
    public Task<T> GetById(int id);
    public void DeleteById(int id);
    public void Update(T entity);
    public Task<T> Add(T entity);
}