

using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Interfaces;
// using SchoolManagementSystem.Domain.Services;
// using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Domain.Services;
public interface IDoStudentPaymentService : IRecordService<Student>
{
    public IRepository<StudentCourseGroupRelation> GetStudentCourseGroupRelationRepo();
    public IRecordRepository<StudentPaymentRecordPerCourseGroup> GetStudentPaymentRecordPerCourseGroupRepo();
    public IRepository<Student> GetStudentRepo();
    public IRepository<CourseGroup> GetCOurseGroupRepo();
    public StudentPaymentRecordPerCourseGroup DoCoursePayment(
                        string studentId, string courseGroupId,
                        string courseId, DateTime DatePaid);

}