
# **Technical Report**

## School Management System

### Authors

* Laura Victoria Riera
* Marcos M. Tirador del Riego
* Leandro Rodriguez Llosa

## Data Dictionary

### 📋 **AdditionalService**

| Atributes                                  | Name                    | Type    |
|--------------------------------------------|-------------------------|---------|
| Primary and foreign 🔑 (to ***Worker***)   | WorkerId                | text    |
| Primary and foreign 🔑 (to ***Resource***) | ResourceId              | text    |
|                                            | WorkerPorcentageProfits | integer |

### 📋 **BasicMean**

| Atributes   | Name              | Type    |
|-------------|-------------------|---------|
| Primary 🔑  | Id                | text    |
|             | Price             | money   |
|             | Type              | text    |
|             | Origin            | text    |
|             | DevaluationInTime | integer |
|             | InaugurationDate  | text    |
|             | Description       | text    |

### 📋 **Classroom**

| Atributes   | Name     | Type    |
|-------------|----------|---------|
| Primary 🔑  | Id       | text    |
|             | Name     | text    |
|             | Capacity | integer |

### 📋 **Course**

| Atributes   | Name  | Type  |
|-------------|-------|-------|
| Primary 🔑  | Id    | text  |
|             | Name  | text  |
|             | Type  | text  |
|             | Price | money |

### 📋 **CourseGroup**

| Atributes                                | Name              | Type    |
|------------------------------------------|-------------------|---------|
| Primary and foreign 🔑 (to ***Course***) | CourseId          | text    |
| Primary and foreign 🔑 (to ***Worker***) | WorkerId          | text    |
|                                          | Capacity          | integer |
|                                          | StartDate         | text    |
|                                          | EndDate           | text    |

### 📋 **Expense**

| Atributes   | Name        |  Type  |
|-------------|-------------|--------|
| Primary 🔑  | Id          |  text  |
|             | Category    |  text  |
|             | Description |  money |

### 📋 **ExpenseRecord**

| Atributes                                 | Name      | Type    |
|-------------------------------------------|-----------|---------|
| Primary and foreign 🔑 (to ***Expense***) | ExpenseId | text    |
|                                           | Date      | text    |
|                                           | Amount    | integer |
|                                           | Value     | money   |

### 📋 **Position**

| Atributes   | Name | Type |
|-------------|------|------|
| Primary 🔑  | Id   | text |
|             | Name | text |

### 📋 **Resource**

| Atributes   | Name     | Type  |
|-------------|----------|-------|
| Primary 🔑  | Id       | text  |
|             | Name     | text  |
|             | Category | text  |
|             | Price    | money |

### 📋 **Schedule**

| Atributes   | Name      | Type    |
|-------------|-----------|---------|
| Primary 🔑  | Id        | text    |
|             | Duration  | text    |
|             | StartTime | text    |
|             | DayOfWeek | integer |

### 📋 **SchoolMember**

| Atributes   | Name              | Type    |
|-------------|-------------------|---------|
| Primary 🔑  | Id                | text    |
|             | CardId            | text    |
|             | Name              | text    |
|             | LastName          | text    |
|             | PhoneNumber       | integer |
|             | Address           | text    |
|             | DateBecomedMember | text    |

### 📋 **Shift**

| Atributes                                     | Name             | Type    |
|-----------------------------------------------|------------------|---------|
| Primary and foreign 🔑 (to ***Classroom***)   | ShiftClassroomId | text    |
| Primary and foreign 🔑 (to ***Schedule***)    | ShiftScheduleId  | text    |
| Primary and foreign 🔑 (to ***CourseGroup***) | CourseGroupId    | text    |

### 📋 **Student**

| Atributes                                      | Name            | Type    |
|------------------------------------------------|-----------------|---------|
| Primary and foreign 🔑 (to ***SchoolMember***) | SchoolMemberId  | text    |
| Foreign 🔑 (to ***Tuitor***)                   | TuitorId        | text    |
|                                                | Founds          | text    |
|                                                | ScholarityLevel | text    |

### 📋 **StudentCourseGroupRelation**

| Atributes                                     | Name                  | Type    |
|-----------------------------------------------|-----------------------|---------|
| Primary and foreign 🔑 (to ***Student***)     | StudentId     | text    |
| Primary and foreign 🔑 (to ***CourseGroup***) | CourseGroupId | text    |
|                                               | StartDate             | text    |
|                                               | EndDate               | text    |

### 📋 **StudentPaymentRecordForAdditionalService**

| Atributes                                           | Name                        | Type    |
|-----------------------------------------------------|-----------------------------|---------|
| Primary and foreign 🔑 (to ***Student***)           | StudentId           | text    |
| Primary and foreign 🔑 (to ***AdditionalService***) | AdditionalServiceId | text    |
|                                                     | Date                        | text    |

### 📋 **StudentPaymentRecordPerCourseGroup**

| Atributes                                     | Name                  | Type    |
|-----------------------------------------------|-----------------------|---------|
| Primary and foreign 🔑 (to ***Student***)     | StudentId     | text    |
| Primary and foreign 🔑 (to ***CourseGroup***) | CourseGroupId | text    |
|                                               | Date                  | text    |

### 📋 **Tuitor**

| Atributes  | Name        | Type    |
|------------|-------------|---------|
| Primary 🔑 | Id          | text    |
|            | Name        | text    |
|            | PhoneNumber | integer |

### 📋 **Worker**

| Atributes                                      | Name           | Type |
|------------------------------------------------|----------------|------|
| Primary and foreign 🔑 (to ***SchoolMember***) | SchoolMemberId | text |

### 📋 **WorkerCourseRelation**

| Atributes                                | Name                    | Type    |
|------------------------------------------|-------------------------|---------|
| Primary and foreign 🔑 (to ***Worker***) | WorkerId        | text    |
| Primary and foreign 🔑 (to ***Course***) | CourseId        | text    |
|                                          | CorrespondingPorcentage | integer |

### 📋 **WorkerGroupRecord**

| Atributes                                     | Name          | Type |
|-----------------------------------------------|---------------|------|
| Primary and foreign 🔑 (to ***Worker***)      | WorkerId      | text |
| Primary and foreign 🔑 (to ***CourseGroup***) | CourseGroupId | text |
|                                               | StartDate     | text |
|                                               | EndDate       | text |

### 📋 **WorkerPayRecordPerCourse**

| Atributes                                | Name           | Type    |
|------------------------------------------|----------------|---------|
| Primary and foreign 🔑 (to ***Worker***) | WorkerId       | text    |
| Primary and foreign 🔑 (to ***Course***) | CourseId       | text    |
|                                          | Date           | text    |
|                                          | PaidPorcentage | integer |

### 📋 **WorkerPayRecordPerPosition**

| Atributes                                  | Name       | Type  |
|--------------------------------------------|------------|-------|
| Primary and foreign 🔑 (to ***Worker***)   | WorkerId   | text  |
| Primary and foreign 🔑 (to ***Position***) | PositionId | text  |
|                                            | Payment    | money |
|                                            | Date       | text  |

### 📋 **WorkerPositionRelation**

| Atributes                                  | Name        | Type  |
|--------------------------------------------|-------------|-------|
| Primary and foreign 🔑 (to ***Worker***)   | WorkerId    | text  |
| Primary and foreign 🔑 (to ***Position***) | PositionId  | text  |
|                                            | FixedSalary | money |

### 📋 **WorkerResourceRelation**

| Atributes                                  | Name                    | Type  |
|--------------------------------------------|-------------------------|-------|
| Primary and foreign 🔑 (to ***Worker***)   | WorkerId                | text  |
| Primary and foreign 🔑 (to ***Resource***) | ResourceId              | text  |
|                                            | CorrespondingPorcentage | money |

## App Layout Outline

![.](./../img/esquema.png)

## Class Schema Defined

```Csharp
interface Identifiable<T>
{
    T Id { get; set; }
}
```

```Csharp
class Entity : Identifiable<string>
{
    string Id { get; set; } 
}
```

```Csharp
interface IRepository<TEntity> where TEntity : Entity
{
    void Save();
    IList<TEntity> GetAll();
}
```

```Csharp
class AdditionalService : Entity
{
    Worker Provider { get; set; }
    
    Resource Resource { get; set; }

    int WorkerPorcentageProfits { get; set; }
}
```

```Csharp
class Classroom : Entity
{
    string Name {get; set;}
    
    int Capacity { get; set; }
}
```

```Csharp
class Course : Entity
{
    int Price { get; set; }
    
    string Type { get; set; }
    
    string Name { get; set; }
}
```

```Csharp
class CourseGroup : Entity
{
    Course Course { get; set; }

    Worker Teacher{ get; set; }

    int Capacity { get; set; }

    DateTime StartDate { get; set; } 

    DateTime EndDate { get; set; }

    IList<Shift> Shifts { get; set; }
}
```

```Csharp
class Expense : Entity
{
    string Category { get; set; }  

    string Description { get; set; }
}
```

```Csharp
class Position : Entity
{
    string Name { get; set; }
}
```

```Csharp
class Resource : Entity
{
    string Name { get; set; }
    
    string Category { get; set; }
    
    int Price{ get; set; }
}
```

```Csharp
class Schedule : Entity
{
    TimeOnly Duration { get; set; }

    TimeOnly StartTime{ get; set; }
    
    DayOfWeek DayOfWeek { get; set; }
}
```

```Csharp
class SchoolMember : Entity
{
    string CardId { get; set; }

    string Name { get; set; }
    
    string LastName { get; set; }
    
    int PhoneNumber{ get; set; }
    
    string Address { get; set; }
    
    DateTime DateBecomedMember { get; set; }
}
```

```Csharp
class Tuitor : Entity
{
    string Name { get; set; }
    
    int PhoneNumber { get; set; }
}
```

```Csharp
class Worker : SchoolMember
{
}
```

```Csharp
class ExpenseRecord
{
    Expense Expense { get; set; }
    
    DateTime Date { get; set; }
    
    int Amount { get; set; }
    
    double Value { get; set; }
}
```

```Csharp
class StudentPaymentRecordForAdditionalService
{
    Student Student { get; set; }
    
    AdditionalService Service { get; set; }
    
    DateTime Date { get; set; }
}
```

```Csharp
class StudentPaymentRecordPerCourseGroup
{
    Student Student { get; set; }
    
    CourseGroup PaidGroup { get; set; }
    
    DateTime PaymentDate { get; set; }
}
```

```Csharp
class WorkerCourseGroupRecord 
{
    Worker Teacher{ get; set; }
    
    CourseGroup Group { get; set; }
    
    DateTime StartDate{ get; set; }

    DateTime EndDate{ get; set; }
}
```

```Csharp
class WorkerPayRecordByPosition 
{
    Worker Worker { get; set; }

    Position Position { get; set; }

    int Payment { get; set; }

    DateTime Date { get; set; }
}
```

```Csharp
class WorkerPayRecordPerCourse 
{
    Worker Teacher { get; set; }
    
    Course PaidCourse{ get; set; }
    
    DateTime Date { get; set; }
    
    int PaidPorcentage { get; set; }
}
```

```Csharp
class SchoolContext : DbContext
{
    // Entities
    DbSet<AdditionalService> AdditionalServices { get; set; }
    DbSet<BasicMean> BasicMeans { get; set; }
    DbSet<Classroom> Classrooms { get; set; }
    DbSet<Course> Courses { get; set; }
    DbSet<CourseGroup> CourseGroups { get; set; }
    DbSet<Expense> Expenses { get; set; }
    DbSet<Position> Positions { get; set; }
    DbSet<Resource> Resources { get; set; }
    DbSet<Schedule> Schedules { get; set; }
    DbSet<SchoolMember> SchoolMembers { get; set; }
    DbSet<Shift> Shifts { get; set; }
    DbSet<Student> Students { get; set; }
    DbSet<Tuitor> Tuitors { get; set; }
    DbSet<Worker> Workers { get; set; }
    
    // Records
    DbSet<ExpenseRecord> ExpenseRecords { get; set; }
    DbSet<StudentPaymentRecordForAdditionalService> StudentPaymentRecordForAdditionalServices { get; set; }
    DbSet<StudentPaymentRecordPerCourseGroup> StudentPaymentRecordPerCourseGroups { get; set; }
    DbSet<WorkerCourseGroupRecord> WorkerCourseGroupRecords { get; set; }
    DbSet<WorkerPayRecordByPosition> WorkerPayRecordByPositions { get; set; }
    DbSet<WorkerPayRecordPerCourse> WorkerPayRecordPerCourses { get; set; }

    void OnModelCreating(ModelBuilder modelBuilder);
}
```

```Csharp
class DbInitializer
{
    void Initialize(SchoolContext context);

    // Seed Database
    AdditionalService[] GetAdditionalServices();
    BasicMean[] GetBasicMeans();
    Classroom[] GetClassrooms();
    Course[] GetCourses();
    CourseGroup[] GetCourseGroups();
    Expense[] GetExpenses();
    Position[] GetPositions();
    Resource[] GetResources();
    Schedule[] GetSchedules();
    SchoolMember[] GetSchoolMembers();
    Shift[] GetShifts();
    Student[] GetStudents();
    Tuitor[] GetTuitors();
    Worker[] GetWorkers();
    ExpenseRecord[] GetExpenseRecords();
    StudentPaymentRecordForAdditionalService[] GetStudentPaymentRecordForAdditionalServices();
    StudentPaymentRecordPerCourseGroup[] GetStudentPaymentRecordPerCourseGroups();
    WorkerCourseGroupRecord[] GetWorkerCourseGroupRecords();
    WorkerPayRecordByPosition[] GetWorkerPayRecordByPositions();
    WorkerPayRecordPerCourse[] GetWorkerPayRecordPerCourses();
}
```

## Use case

Dejamos una muestra de como sería la implementación de un caso de uso; la funcionalidad `Create()` del modelo `Classroom`. De manera análoga se implementan las demás funcionalidades. Siempre dada una vista, se dedica un controlador para esta (en la carpeta *Controllers/ClassroomController.cs*), teniendo sus métodos de acción. La vista dedica para cada caso de uso se encuentra en el directorio *Views/Classrooms/Create.cshtml*

```Csharp
class ClassroomRepository : IRepository<Classroom>
{
    SchoolContext _context;

    ClassroomRepository(SchoolContext context)
    {
        _context = context;
    }

    IList<Classroom> GetAll()
    {
        return _context.Classrooms.ToList();
    }

    void Save()
    {
        _context.SaveChangesAsync();
    }
}
```

```Csharp
class ClassroomsController : Controller
{
    private readonly IRepository<Classroom> _repository;

    ClassroomsController(IRepository<Classroom> repository)
    {
        _repository = repository;
    }

    IActionResult Index()
    {
        return View(_repository.GetAll());
    }

    IActionResult Create()
    {
        return View();
    }

    // Other func ...
}


```
<!-- ```mermaid
classDiagram
      class Identifiable~string~
      <<interface>> Identifiable~string~
      Entity ..|> Identifiable~string~ : implements
      Entity <|-- BasicMean
      Entity <|-- Classroom
      Entity <|-- Course
      Entity <|-- CourseGroup
      Entity <|-- Expense
      Entity <|-- Position
      Entity <|-- Resource
      Entity <|-- Schedule
      Entity <|-- SchoolMember
      Entity <|-- Shift
      Entity <|-- Student
      Entity <|-- Tuitor
      Entity <|-- Worker
      class Entity{
        string Id  
      }
      
``` -->
