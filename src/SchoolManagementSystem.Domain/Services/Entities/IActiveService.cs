using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;

namespace SchoolManagementSystem.Domain.Services;

public interface IActiveService<TEntity> : IService<TEntity> where TEntity : Entity
{
    IQueryable<TEntity> QueryInactives();
}
