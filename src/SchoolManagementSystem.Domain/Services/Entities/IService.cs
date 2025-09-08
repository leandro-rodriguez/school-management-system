using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;

namespace SchoolManagementSystem.Domain.Services;

public interface IService<TEntity> where TEntity : class
{
    IQueryable<TEntity> Query();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    // void SaveAsync();
    void Commit();
    Task CommitAsync();
}
