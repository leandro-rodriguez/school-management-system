
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class BaseRecordService<TEntity> : IRecordService<TEntity> where TEntity : class
{
    public BaseRecordService(IRecordRepository<TEntity> repository)
    {
        BaseRepository = repository;
    }

    protected IRecordRepository<TEntity> BaseRepository { get; }

    public virtual IQueryable<TEntity> Query() => BaseRepository.Query();
    
    public void Add(TEntity entity) => BaseRepository.Add(entity);

    public void Commit() => BaseRepository.Commit();

    public Task CommitAsync() => BaseRepository.CommitAsync();
}
