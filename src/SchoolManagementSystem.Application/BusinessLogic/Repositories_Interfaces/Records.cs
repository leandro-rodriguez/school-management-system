
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Records;

namespace SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

public interface IExpenseRecordRepository : IRecordRepository<ExpenseRecord>
{

}

public interface IStudentPayCourseRecordRepository : IRecordRepository<StudentPaymentRecordPerCourseGroup>
{

}

public interface ITeacherPayRecordPerCourseRepository : IRecordRepository<TeacherPayRecordPerCourse>
{

}

public interface IWorkerPayRecordByPositionRepository : IRecordRepository<WorkerPayRecordByPosition>
{

}