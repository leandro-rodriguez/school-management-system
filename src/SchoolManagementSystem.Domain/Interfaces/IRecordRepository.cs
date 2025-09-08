
namespace SchoolManagementSystem.Domain.Interfaces
{
    public interface IRecordRepository<TEntity>
    {
        IObjectContext Context { get; }
        IQueryable<TEntity> Query();
        void Add(TEntity entity);
        void Commit();
        Task CommitAsync();
    }
}
