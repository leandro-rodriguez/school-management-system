
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;
// using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class ConsultWorkerSalaryService : BaseRecordService<Worker>, IConsultWorkerSalaryService
{
    IWorkerPayRecordByPositionRepository repoPositionPayments;
    ITeacherPayRecordPerCourseRepository repoTeacherPayments;
    ITeacherCourseGroupRelationRepository tCGR_repo;
    ITeacherCourseRelationRepository tCR_repo;
    public ConsultWorkerSalaryService(ITeacherCourseRelationRepository tCR_repo,
                                    ITeacherCourseGroupRelationRepository tCGR_repo,
                                    IWorkerPayRecordByPositionRepository repo_1,
                                    ITeacherPayRecordPerCourseRepository repo_2,
                                    IWorkerRepository base_repo) : base(base_repo)
    {
        repoPositionPayments = repo_1;
        repoTeacherPayments = repo_2;
        this.tCR_repo = tCR_repo;
        this.tCGR_repo = tCGR_repo;

    }
    public List<int> Proof()
    {
        return new List<int> { 1, 2, 3, 4 };
    }

    public IQueryable<TeacherPayRecordPerCourse> GetWorkerCoursePorcentualSalariesByDate(string id, DateTime date)
    {
        var _query = repoTeacherPayments.Query()
                       .Where(c => id == c.TeacherId)
                       .Include(c => c.Course.CourseGroups)
                       .Where(c => date == c.Date);

        return _query;
    }

    public IQueryable<WorkerPayRecordByPosition> GetWorkerFixSalariesByDate(string id, DateTime date)
    {
        var ans = new List<Tuple<string, int>>();
        var _query = repoPositionPayments.Query()
                        .Where(c => id == c.WorkerId)
                        .Include(c => c.Position)
                        .Where(c => c.Date == date);

        return _query;
    }

    public List<DateTime> GetAllPaymentDates(string id)
    {
        List<DateTime> dates = new List<DateTime>();
        var _query = repoPositionPayments.Query()
                        .Where(c => id == c.WorkerId);
        foreach (var item in _query)
            dates.Add(item.Date);
        var _query2 = repoTeacherPayments.Query()
                        .Where(c => id == c.TeacherId);

        foreach (var item in _query2)
            dates.Add(item.Date);

        dates = dates.Distinct().ToList();

        return dates;
    }
    public IRepository<TeacherCourseGroupRelation> GetTeacherCourseGroupRelationRepo()
    {
        return tCGR_repo;
    }
    public IRepository<TeacherCourseRelation> GetTeacherCourseRelationRepo(){
        return tCR_repo;

    }
}
