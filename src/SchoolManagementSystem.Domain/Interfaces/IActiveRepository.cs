
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Interfaces;

public interface IActiveRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> QueryInactives();
}
