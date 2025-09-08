
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;



public class ActiveService<TEntity> : BaseService<TEntity>, IActiveService<TEntity> where TEntity : Entity
{
    new IActiveRepository<TEntity> BaseRepository;
    public ActiveService(IActiveRepository<TEntity> repository) : base(repository)
    {
        BaseRepository = repository;
    }

    public IQueryable<TEntity> QueryAll()
    {
        var inactiveEntities = BaseRepository.QueryInactives();
        var activeEntities = BaseRepository.Query();

        return inactiveEntities.Union(activeEntities);
    }

    public IQueryable<TEntity> QueryInactives() => BaseRepository.QueryInactives();

}
