
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class DoStudentPaymentService : BaseService<Student>, IDoStudentPaymentService
{
    IStudentRepository _studentRepo;
    ICourseGroupRepository _courseGroupRepo;
    IStudentCourseGroupRelationRepository _studentCourseRelation;
    IStudentPayCourseRecordRepository _studentCourseRecord;    

    public DoStudentPaymentService(IStudentRepository studentRepo,
                                    ICourseGroupRepository courseGroupRepo,
                                    IStudentCourseGroupRelationRepository studentCourseRelation,
                                    IStudentPayCourseRecordRepository studentCourseRepository)
        : base(studentRepo)
    {
        _studentRepo = studentRepo;
        _courseGroupRepo = courseGroupRepo;
        _studentCourseRelation = studentCourseRelation;
        _studentCourseRecord = studentCourseRepository;
    }

    public StudentPaymentRecordPerCourseGroup DoCoursePayment(string studentId, string courseGroupId,
                        string courseId, DateTime DatePaid)
    {
        var record = new StudentPaymentRecordPerCourseGroup
        {
            StudentId = studentId,
            CourseGroupId = courseGroupId,
            CourseGroupCourseId = courseId,
            DatePaid = DatePaid,
            Date = DateTime.Now,
            //Student = _studentRepo.Query().First(s => s.Id == studentId),
            //CourseGroup = _courseGroupRepo.Query().First(s => s.Id == courseId),
        };
        _studentCourseRecord.Add(record);        
        _studentCourseRelation.CommitAsync();
        return record;        
    }

    public IRepository<CourseGroup> GetCOurseGroupRepo()
    {
        return _courseGroupRepo;
    }

    public IRepository<StudentCourseGroupRelation> GetStudentCourseGroupRelationRepo()
    {
        return _studentCourseRelation;
    }

    public IRecordRepository<StudentPaymentRecordPerCourseGroup> GetStudentPaymentRecordPerCourseGroupRepo()
    {
        return _studentCourseRecord;
    }

    public IRepository<Student> GetStudentRepo()
    {
        return _studentRepo;
    }
}