using SchoolManagementSystem.Domain.Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class RecordRepository<TEntity> : IRecordRepository<TEntity> where TEntity : class
    {
        public RecordRepository(IObjectContext context)
        {
            Context = context;
        }

        public IObjectContext Context { get; }

        public IQueryable<TEntity> Query() => Context.Query<TEntity>();

        public void Add(TEntity entity) => Context.Add(entity);

        public void Commit() => Context.Commit();

        public Task CommitAsync() => Context.CommitAsync();
    }

}
