using SchoolManagementSystem.Domain.Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class CrudRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public CrudRepository(IObjectContext context)
        {
            Context = context;
        }

        public IObjectContext Context { get; }

        public virtual IQueryable<TEntity> Query() => Context.Query<TEntity>();

        public void Add(TEntity entity) => Context.Add(entity);

        public void Update(TEntity entity) => Context.Update(entity);

        public void Remove(TEntity entity) => Context.Remove(entity);

        public void Commit() => Context.Commit();

        public Task CommitAsync() => Context.CommitAsync();
    }

};
