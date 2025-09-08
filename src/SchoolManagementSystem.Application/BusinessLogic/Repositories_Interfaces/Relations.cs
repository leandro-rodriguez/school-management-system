
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

public interface IShiftRepository : IRepository<Shift>
{

}

public interface IStudentCourseGroupRelationRepository : IRepository<StudentCourseGroupRelation>
{

}

public interface ITeacherCourseGroupRelationRepository : IRepository<TeacherCourseGroupRelation>
{

}

public interface ITeacherCourseRelationRepository : IRepository<TeacherCourseRelation>
{

}

public interface IWorkerPositionRelationRepository : IRepository<WorkerPositionRelation>
{

}