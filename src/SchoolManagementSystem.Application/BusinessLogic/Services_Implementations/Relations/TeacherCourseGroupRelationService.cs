
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class TeacherCourseGroupRelationService : BaseService<TeacherCourseGroupRelation>, ITeacherCourseGroupRelationService
{
    ITeacherCourseGroupRelationRepository repo;
    ITeacherCourseRelationRepository tcr_repo;
    ITeacherRepository tch_repo;
    ICourseGroupRepository cgrs_repo;
    public TeacherCourseGroupRelationService(ITeacherCourseRelationRepository tcr_repo,
            ICourseGroupRepository cgrs_repo,
            ITeacherRepository tch_repo,
             ITeacherCourseGroupRelationRepository repository) : base(repository)
    {
        this.repo = repository;
        this.tch_repo = tch_repo;
        this.cgrs_repo = cgrs_repo;
        this.tcr_repo = tcr_repo;
    }
    public bool ValidateIds(string TeacherId, string CourseGroupId, string CourseId)
    {
        var row = cgrs_repo.Query().Where(c => c.Id == CourseGroupId && c.CourseId == CourseId) 
                            .FirstOrDefault();

        if (row == null)
            return false;

        var std = tch_repo.Query().Where(c => c.Id == TeacherId)
                            .FirstOrDefault();
        if (std == null)
            return false;

        return true;
    }
    public void AddTeacherCourseRelation(TeacherCourseRelation item)
    {
        tcr_repo.Add(item);
        tch_repo.CommitAsync();
    }
}