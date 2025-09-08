using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class ActiveRepository<TEntity> : CrudRepository<TEntity> where TEntity : Entity
{
    public ActiveRepository(IObjectContext context) : base(context)
    {

    }
    public override IQueryable<TEntity> Query()
    {
        return base.Query().Where(c => c.Active == true);
    }
    public IQueryable<TEntity> QueryInactives()
    {
        return base.Query().Where(c => c.Active == false);
    }

}