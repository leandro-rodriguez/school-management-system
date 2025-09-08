
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

namespace SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;

public class StudentPayCourseRecordService : BaseRecordService<StudentPaymentRecordPerCourseGroup>, IStudentPayCourseRecordService
{
    public StudentPayCourseRecordService(IStudentPayCourseRecordRepository repository) : base(repository)
    {

    }
}