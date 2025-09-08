
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.BusinessLogic.Repositories_Interfaces;

public interface IBasicMeanRepository : IActiveRepository<BasicMean>
{

}

public interface IClassroomRepository : IActiveRepository<Classroom>
{

}

public interface ICourseGroupRepository : IActiveRepository<CourseGroup>
{
    CourseGroup GetById(string id);
}

public interface ICourseRepository : IActiveRepository<Course>
{

}

public interface IExpenseRepository : IActiveRepository<Expense>
{

}

public interface IPositionRepository : IActiveRepository<Position>
{

}

public interface IResourceRepository : IActiveRepository<Resource>
{

}

public interface ISchoolMemberRepository : IActiveRepository<SchoolMember>
{

}

public interface IStudentRepository : IActiveRepository<Student>
{
    /// Devuelve el estudiante con ese id
    /// En caso de no existir devuelve null
    Student GetById(string id);
}

public interface ITeacherRepository : IActiveRepository<Teacher>
{

}

public interface ITuitorRepository : IActiveRepository<Tuitor>
{

}

public interface IWorkerRepository : IActiveRepository<Worker>
{

}