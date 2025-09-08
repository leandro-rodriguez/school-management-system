
using SchoolManagementSystem.Domain;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;
// using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class DoWorkersPaymentService : BaseRecordService<Worker>, IDoWorkersPaymentService
{
    IWorkerPositionRelationRepository repoWorkerPositionR;
    IWorkerPayRecordByPositionRepository repoPositionPayments;
    ITeacherPayRecordPerCourseRepository repoTeacherPayments;
    ITeacherCourseGroupRelationRepository repoTeacherCGREl;
    ITeacherCourseRelationRepository repoTeacherCourseRel;
    // ICourseGroupRepository repoCG;
    public DoWorkersPaymentService(IWorkerPositionRelationRepository repoWorkerPositionR,
                                    ITeacherCourseRelationRepository repoTeacherCourseRel,
                                    ITeacherCourseGroupRelationRepository repoTeacherCGREl,
                                    IWorkerPayRecordByPositionRepository repo_1,
                                    ITeacherPayRecordPerCourseRepository repo_2,
                                    IWorkerRepository base_repo) : base(base_repo)
    {
        repoPositionPayments = repo_1;
        repoTeacherPayments = repo_2;
        this.repoTeacherCGREl = repoTeacherCGREl;
        this.repoTeacherCourseRel = repoTeacherCourseRel;
        this.repoWorkerPositionR = repoWorkerPositionR;
    }
    public IRepository<TeacherCourseGroupRelation> GetTeacherCourseGroupRelationRepo()
    {
        return repoTeacherCGREl;
    }
    public IRepository<WorkerPositionRelation> GetWorkerPositionRelationRepo()
    {
        return repoWorkerPositionR;
    }
    public IRepository<TeacherCourseRelation> GetTeacherCourseRelationRepo()
    {
        return repoTeacherCourseRel;
    }
    public void DoPositionPayment(DateTime Date, string WorkerId)
    {
        var _query = repoWorkerPositionR.Query().Where(c => c.WorkerId == WorkerId && c.StartDate < Date
                                                                              && c.EndDate >= Date);
        foreach (var row in _query)
        {
            repoPositionPayments.Add(new WorkerPayRecordByPosition()
            {
                Date = Date,
                Payment = row.FixedSalary,
                PositionId = row.PositionId,
                WorkerId = row.WorkerId
            });
        }
        repoPositionPayments.CommitAsync();
    }
    public void DoCoursePayment(DateTime Date, string WorkerId)
    {
        var _query = repoTeacherCourseRel.Query().Where(c => c.TeacherId== WorkerId);
        foreach (var row in _query)
        {
            repoTeacherPayments.Add(new TeacherPayRecordPerCourse()
            {
                Date = Date,
                CourseId = row.CourseId,
                PaidPorcentage = row.CorrespondingPorcentage,
                TeacherId = WorkerId
            });
        }
        repoTeacherPayments.CommitAsync();
    }

    public WorkerPaymentInfo GetWorkerPaymentInfo(string id, DateTime Date)
    {
        var worker = this.Query().SingleOrDefault(c => c.Id == id);
        var workerPaymentInfo = new WorkerPaymentInfo
        {
            Id = id,
            WorkerName = worker.Name,
            InfoByDate = new List<InfoByDate>(){new InfoByDate{
                    InfoByPosition = new List<InfoByPosition>(),
                    InfoByCourse = new List<InfoByCourse>(),
                    Date = Date
                }},
        };

        var _query = from wPR in repoWorkerPositionR.Query().Include(c => c.Position).Where(c => c.WorkerId == id && c.StartDate < workerPaymentInfo.InfoByDate[0].Date
                                                                                                    && c.EndDate >= workerPaymentInfo.InfoByDate[0].Date)
                     select new { wPR.PositionId, salary = wPR.FixedSalary, Name = wPR.Position.Name };

        foreach (var row in _query)
        {
            workerPaymentInfo.InfoByDate[0].InfoByPosition.Add(
                new InfoByPosition
                {
                    Position = row.Name,
                    PositionId = row.PositionId,
                    FixSalaryPosition = row.salary
                }
            );
        }
        foreach (var info in workerPaymentInfo.InfoByDate)
        {
            var _querytcr = repoTeacherCourseRel.Query().Where(c => c.TeacherId == id).Include(c => c.Course);
            foreach (var row in _querytcr)
            {
                InfoByCourse course = new InfoByCourse()
                {
                    CourseId = row.CourseId,
                    CourseName = row.Course.Name,
                    Porcentage = row.CorrespondingPorcentage,
                    InfoByCourseGroup = new List<InfoByCourseGroup>()
                };
                var _querytcgr = repoTeacherCGREl.Query().Where(c => c.TeacherId == id 
                                                            && c.CourseGroupCourseId == course.CourseId
                                                            && c.StartDate <= Date
                                                            && c.EndDate >= Date
                                                            )
                                                    .Include(c => c.CourseGroup.StudentCourseGroupRelations);
                foreach (var group in _querytcgr)
                {
                    var income = group.CourseGroup.StudentCourseGroupRelations.Where(c => c.StartDate <= info.Date && c.EndDate >= info.Date).Count() * row.Course.Price;
                    course.InfoByCourseGroup.Add(new InfoByCourseGroup()
                    {
                        CourseGroupId = group.CourseGroup.Id
                        ,
                        CourseGroupName = group.CourseGroup.Name
                        ,
                        CourseGroupIncome = income
                        ,
                        CourseGroupWorkerPayment = ((double)(1.0) / 100) * income * course.Porcentage
                    });
                }
                workerPaymentInfo.InfoByDate[0].InfoByCourse.Add(course);
            }

        }
        return workerPaymentInfo;
    }

}