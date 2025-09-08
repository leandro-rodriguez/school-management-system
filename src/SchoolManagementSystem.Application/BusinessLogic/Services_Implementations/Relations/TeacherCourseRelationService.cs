
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class TeacherCourseRelationService : BaseService<TeacherCourseRelation>, ITeacherCourseRelationService
{
    ITeacherCourseRelationRepository repo;
    ITeacherRepository tch_repo;
    ICourseRepository crs_repo;
    public TeacherCourseRelationService(ICourseRepository crs_repo,
            ITeacherRepository tch_repo,
             ITeacherCourseRelationRepository repository) : base(repository)
    {
        this.repo = repository;
        this.tch_repo = tch_repo;
        this.crs_repo = crs_repo;
    }
    public bool ValidateIds(string TeacherId, string CourseId)
    {
        var row = crs_repo.Query().Where(c => c.Id == CourseId)
                            .FirstOrDefault();

        if (row == null)
            return false;

        var std = tch_repo.Query().Where(c => c.Id == TeacherId)
                            .FirstOrDefault();
        if (std == null)
            return false;

        return true;
    }
}