
namespace SchoolManagementSystem.Domain.Interfaces;

public interface IRepository<TEntity> : IRecordRepository<TEntity> where TEntity : class
{
    void Update(TEntity entity);
    void Remove(TEntity entity);
}
