
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Application.Authenticate.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace SchoolManagementSystem.Infrastructure.Data;

public static class SchoolInitializer
{
    #region Entities for add to other entities


    static Teacher carmen = new Teacher{
        Name = "Carmen",
        LastName = "Gonzalez",
        Address = "Calle Conchita",
        IDCardNo = "091283928",
        DateBecomedMember = new DateTime(2012,09,21),
        PhoneNumber = 58981234
    };
    static Teacher juan = new Teacher{
        Name = "Juan",
        LastName = "Rodriguz",
        Address = "Calle Paz",
        IDCardNo = "90871238292",
        DateBecomedMember = new DateTime(2015,09,21),
        PhoneNumber = 57891234
    };
    static Tuitor frank = new Tuitor{
        Name = "Frank",
        PhoneNumber = 57881239,
    };
    static Tuitor roger = new Tuitor { Name = "Roger", PhoneNumber = 54444444 };

    #region Students
    static Student sasha = new Student{
        Name = "Sasha",
        LastName = "hernand",
        Address = "Calle Victoria",
        IDCardNo = "90831243234",
        DateBecomedMember = new DateTime(2019,06,15),
        PhoneNumber = 56781239,
        Founds = 12,
        ScholarityLevel = Domain.Enums.Education.Posgrado,
        Tuitor = frank
    };
    static Student sandra = new Student{
        Name = "Sandra",
        LastName = "Jimenez",
        Address = "Calle Pancha",
        IDCardNo = "02293881244",
        DateBecomedMember = new DateTime(2021,08,21),
        PhoneNumber = 59871304,
        Founds = 145,
        ScholarityLevel = Domain.Enums.Education.TecnicoMedio,
        Tuitor = frank
    };
    static Student Hermen = new Student{
        Name = "Hermen",
        LastName = "Cartan",
        Address = "Calle Pencil",
        IDCardNo = "98130923454",
        DateBecomedMember = new DateTime(2014,09,28),
        PhoneNumber = 56813049,
        Founds = 102,
        ScholarityLevel = Domain.Enums.Education.Primaria,
        Tuitor = frank
    };
    static Student Rodrigo = new Student{
        Name = "Rodrigo",
        LastName = "Posada",
        Address = "Calle Vento",
        IDCardNo = "06871223456",
        DateBecomedMember = new DateTime(2021,06,15),
        PhoneNumber = 57893019,
        Founds = 120,
        ScholarityLevel = Domain.Enums.Education.Secundaria,
        Tuitor = frank
    };
    static Student Carlos = new Student{
        Name = "Carlos",
        LastName = "Yatra",
        Address = "Calle Guntilla",
        IDCardNo = "98052378290",
        DateBecomedMember = new DateTime(2019,06,15),
        PhoneNumber = 56781239,
        Founds = 134,
        ScholarityLevel = Domain.Enums.Education.Preuniversitario,
        Tuitor = frank
    };
    static Student Jorgito = new Student { 
        IDCardNo = "14253681562", 
        Name = "Jorgito", 
        LastName = "Gonzalez Gutierrez",
        PhoneNumber = 54763443,
        Address = "Test Direccion de jorgito",
        DateBecomedMember = new DateTime(2022, 3, 5),
        ScholarityLevel = Domain.Enums.Education.Primaria
};
    static Student Guillermo = new Student
    {
        IDCardNo = "99111165645",
        Name = "Guillermo",
        LastName = "Rodriguez de Vivar",
        PhoneNumber = 53545515,
        Address = "Test Direccion de Guillermo",
        DateBecomedMember = new DateTime(2020, 11, 25),
        Tuitor = roger,
        Founds = 2,
        ScholarityLevel = Domain.Enums.Education.Universidad
    };
        
    #endregion

    #region Positions
    static Position director = new Position{
        Name = "director"
    };
    static Position secretaria = new Position{
        Name = "secretaria"
    };
    static Position asistente = new Position{
        Name = "asistente"
    };
    #endregion

    #region Courses
    static Course aleman = new Course { Name = "Aleman 1", Price = 55, Type = "Idioma" };
    static Course algebra = new Course{
        Name = "Algebra",
        Price =  200,
        Type = "Mates"
    };
    static Course logica = new Course{
        Name = "logica",
        Price =  200,
        Type = "Mates"
    };
    static Course geometria = new Course{
        Name = "geometria",
        Price =  200,
        Type = "Mates"
    };
    static Course historia = new Course{
        Name = "Historia",
        Price =  200,
        Type = "Letras"
    };
    #endregion
        
    #region CourseGroups
    static CourseGroup algebralineal = new CourseGroup{
        Name = "AlgebraLineal",
        Course = algebra,
        Teacher = juan,
        CourseId = algebra.Id,
        Capacity = 30,
        StartDate = new DateTime(2020,01,01),
        EndDate = new DateTime(2020,09,20),
    };
    static CourseGroup algebra2 = new CourseGroup{
        Name = "Algebra2",
        Course = algebra,
        CourseId = algebra.Id,
        Teacher = juan,
        Capacity = 30,
        StartDate = new DateTime(2020,01,02),
        EndDate = new DateTime(2020,12,02),
    };
    static CourseGroup geometriaespacial = new CourseGroup{
        Name = "geometria es",
        Course = geometria,
        CourseId = geometria.Id,
        Capacity = 20,
        StartDate = new DateTime(2020,01,01),
        EndDate = new DateTime(2020,05,20),
    };
    static CourseGroup historiaDelArte = new CourseGroup{
        Name = "historiaDA",
        Course = historia,
        Teacher = carmen,
        CourseId = historia.Id,
        Capacity = 30,
        StartDate = new DateTime(2020,01,01),
        EndDate = new DateTime(2020,11,09),
    };
    static CourseGroup Aleman = new CourseGroup
    {
        Course = aleman,
        Name = "Aula T2",
        Capacity = 14,
        StartDate = new DateTime(2022, 3, 12),
        EndDate = new DateTime(2022, 5, 12),
        Teacher = new Teacher
        {
            IDCardNo = "00523573122",
            Name = "Leo",
            LastName = "LLosa",
            PhoneNumber = 55555555,
            Address = "Calle Berlin",
            DateBecomedMember = new DateTime(2020, 5, 14),
            CourseGroups = new List<CourseGroup>()
        }
    };

    #endregion

    #endregion
    public static void Initialize(SchoolContext context) 
    {

        // Entities
        if (!context.AdditionalServices.Any())
        {
            context.AdditionalServices
                .AddRangeAsync(
                    GetAdditionalServices()
                );
        }
        if (!context.BasicMeans.Any())
        {
            context.BasicMeans
                .AddRangeAsync(
                    GetBasicMeans()
                );
        }
        if (!context.Classrooms.Any())
        {
            context.Classrooms
                .AddRangeAsync(
                    GetClassrooms()
                );
        }
        if (!context.Courses.Any())
        {
            context.Courses
                .AddRangeAsync(
                    GetCourses()
                );
        }
        if (!context.CourseGroups.Any())
        {
            context.CourseGroups
                .AddRangeAsync(
                    GetCourseGroups()
                );
        }
        if (!context.Expenses.Any())
        {
            var expenses = GetExpenses();
            context.Expenses
                .AddRangeAsync(
                    expenses
                );
            Console.WriteLine(expenses[0].Id);
        }
        if (!context.Positions.Any())
        {
            context.Positions
                .AddRangeAsync(
                    GetPositions()
                );
        }
        if (!context.Resources.Any())
        {
            var resources = GetResources();
            
            context.Resources
                .AddRangeAsync(
                    resources
                );
        }
        if (!context.Schedules.Any())
        {
            context.Schedules
                .AddRangeAsync(
                    GetSchedules()
                );
        }
        if (!context.SchoolMembers.Any())
        {
            context.SchoolMembers
                .AddRangeAsync(
                    GetSchoolMembers()
                );
            context.AddRangeAsync(
                    GetStudents()
                );
            context.AddRangeAsync(
                    GetTeachers()
                );
            context.AddRangeAsync(
                    GetWorkers()
                );
        }
        if (!context.Shifts.Any())
        {
            context.Shifts
                .AddRangeAsync(
                    GetShifts()
                );
        }
        if (!context.Tuitors.Any())
        {
            context.Tuitors
                .AddRangeAsync(
                    GetTuitors()
                );
        }     
        // Records
        if (!context.ExpenseRecords.Any())
        {
            context.ExpenseRecords
                .AddRangeAsync(
                    GetExpenseRecords()
                );
        }
        if (!context.StudentPaymentRecordForAdditionalServices.Any())
        {
            context.StudentPaymentRecordForAdditionalServices
                .AddRangeAsync(
                    GetStudentPaymentRecordForAdditionalServices()
                );
        }
        if (!context.StudentPaymentRecordPerCourseGroups.Any())
        {
            context.StudentPaymentRecordPerCourseGroups
                .AddRangeAsync(
                    GetStudentPaymentRecordPerCourseGroups()
                );
        }
        if (!context.WorkerPayRecordByPositions.Any())
        {
            context.WorkerPayRecordByPositions
                .AddRangeAsync(
                    GetWorkerPayRecordByPositions()
                );
        }
        if (!context.TeacherPayRecordPerCourses.Any())
        {
            context.TeacherPayRecordPerCourses
                .AddRangeAsync(
                    GetTeacherPayRecordPerCourses()
                );
        }
        // Relations  
        if (!context.StudentCourseGroupRelations.Any())
        {
            context.StudentCourseGroupRelations
                .AddRangeAsync(
                    GetStudentCourseGroupRelations()
                );
        }
        if (!context.TeacherCourseGroupRelations.Any())
        {
            context.TeacherCourseGroupRelations
                .AddRangeAsync(
                    GetTeacherCourseGroupRelations()
                );
        }
        if (!context.TeacherCourseRelations.Any())
        {
            context.TeacherCourseRelations
                .AddRangeAsync(
                    GetTeacherCourseRelations()
                );
        }
        if (!context.WorkerPositionRelations.Any())
        {
            context.WorkerPositionRelations
                .AddRangeAsync(
                    GetWorkerPositionRelations()
                );
        }

        context.SaveChangesAsync();
    }

    #region Seed Database

    #region Entitites
    private static AdditionalService[] GetAdditionalServices()
    {
        return new AdditionalService[]
        {
            new AdditionalService {Worker = new Worker { IDCardNo = "99122104222", Name = "Luis",
                LastName = "Guerrero", PhoneNumber = 52372293, 
                Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) },
                Resource = new Resource { Name = "libro de Ingles basico", Category = "Cuaderno", Price = 1000, 
                Providers = new List<Worker>() } , WorkerPorcentageProfits = 15}
        };
    }
    
    private static BasicMean[] GetBasicMeans()
    {
        return new []
        {
            new BasicMean{ Type="Sofa", Origin = "MLC", Price = 200 , DevaluationInTime = 10,
                Description = "Sofa para la entrada, de color carmelita" , 
                InaugurationDate = new DateTime(2021,1,4) }
        };
    }
    
    private static Classroom[] GetClassrooms()
    {
        return new Classroom[]
        {
            new Classroom { Name = "Aula 1", Capacity = 30 },
            new Classroom { Name = "Aula 2", Capacity = 20 },
            new Classroom { Name = "Aula 3", Capacity = 16 }
        };
    }
    
    private static Course[] GetCourses()
    {
        return new Course[]
        {
            new Course { Name = "Transito 101", Price = 16, Type = "Transito" },
            new Course { Name = "Transito 102", Price = 18, Type = "Transito" },
            new Course { Name = "Transito 103", Price = 20, Type = "Transito" }
        };
    }
    
    private static CourseGroup[] GetCourseGroups()
    {
        return new CourseGroup[]
        {
            new CourseGroup
            {
                Course = new Course { Name = "Transito 101", Price = 16, Type = "Transito" },
                Name = "Aula T1",
                Capacity = 16,
                StartDate = new DateTime(2022, 3, 12),
                EndDate = new DateTime(2022, 5, 12),
                Teacher = new Teacher{ IDCardNo="00522627123", Name = "juanito", LastName = "tirador", PhoneNumber = 76444081,
                    Address = "Calle Cotilla", DateBecomedMember = new DateTime(2020, 5, 14), 
                    CourseGroups = new List<CourseGroup>() }
                // Shifts = new List<Shift>(),
            }
        };
    }
    
    private static Expense[] GetExpenses()
    {
        return new Expense[]
        {
            new Expense { Category = "inmueble", Description = "empty" },
            new Expense { Category = "comida", Description = "empty" },
            new Expense { Category = "pizarras", Description = "empty" },
    
        };
    }
    
    private static Position[] GetPositions()
    {
        return new Position[]
        {
            new Position { Name = "director", Workers = new List<Worker>()},
            new Position { Name = "secretaria", Workers = new List<Worker>() },
            new Position { Name = "asistente", Workers = new List<Worker>() }
        };
    }
    
    private static Resource[] GetResources()
    {   
        return new Resource[]
        {
            new Resource { Name = "libro de mates", Category = "Libros", Price = 100, 
                Providers = new List<Worker>() /* {
                new Worker { Id = "99123100221", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }
                } */
            },
            new Resource { Name = "libro de ingles", Category = "Libros", Price = 100, 
                Providers = new List<Worker>() /* {
                new Worker { Id = "99123149221", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }
                } */
            },
            new Resource { Name = "libro de historia", Category = "Libros", Price = 100, 
                Providers = new List<Worker>() /* {
                new Worker { Id = "99123102721", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }
                } */
            }
        };
    }
    
    private static Schedule[] GetSchedules()
    {
        return new Schedule[3]
        {
            new Schedule 
                { EndTime = new DateTime(2020,08,09), StartTime = new DateTime(2020,08,08) },
            new Schedule 
                { EndTime = new DateTime(2020,08,10), StartTime = new DateTime(2020,08,9) },
            new Schedule
                { EndTime = new DateTime(2020,08,11), StartTime = new DateTime(2020,08,10) },
        };
    }
    
    private static SchoolMember[] GetSchoolMembers()
    {
        var schoolMember = new SchoolMember { IDCardNo = "98012134289", Name = "Leandro", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) };
    
        return new SchoolMember[]
        {
            schoolMember,
            new SchoolMember { IDCardNo = "98022134289", Name = "Leandro", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) },
            new SchoolMember { IDCardNo = "98012334289", Name = "Leandro", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }
        };
    }
    
    private static Shift[] GetShifts()
    {
        return new Shift[]
        {
            new Shift
            {
                Classroom = new Classroom { Name = "Aula 1", Capacity = 30 }, Schedule = new Schedule
                    { EndTime = new DateTime(2022,05,29,14,30,0), StartTime = new (2022,05,29,13,0,0),
                    //  DayOfWeek = DayOfWeek.Friday 
                    }
                ,Group = algebra2
                ,Description = "Algebra 2 - Teacher : Juan Rodriguez"
            },
            new Shift
            {
                Classroom = new Classroom { Name = "Aula 2", Capacity = 20 }, Schedule = new Schedule
                    { EndTime = new DateTime(2022,05,27,12,30,0), StartTime = new (2022,05,27,11,0,0), 
                    // DayOfWeek = DayOfWeek.Monday 
                    }
                ,Description = "Algebra lineal - Teacher : Juan Rodriguez"
                ,Group = algebralineal
            },
            new Shift
            {
                Classroom = new Classroom { Name = "Aula 3", Capacity = 16 }, Schedule = new Schedule
                    { EndTime = new DateTime(2022,05,28,13,55,0), StartTime = new (2022,05,28,12,25,0), 
                    // DayOfWeek = DayOfWeek.Tuesday 
                    }
                ,Description = "Historia del Arte - Teacher : Carmen"
                ,Group = historiaDelArte
            }
    
        };
    }
    
    private static Student[] GetStudents()
    {
        return new Student[2]
        {
            new Student { IDCardNo = "123456784012", Name = "Pablo", LastName = "Curbelo Paez", PhoneNumber = 56784392,
                Address = "Pocitos No.23 e/ Czda de Vento y ALmendares", 
                DateBecomedMember = new DateTime(2020, 2, 1),
                Tuitor = new Tuitor { Name = "Elena", PhoneNumber = 54637721 }, Founds = 3, 
                ScholarityLevel = Domain.Enums.Education.Posgrado },
            new Student { IDCardNo = "12312312312", Name = "Pablito", LastName = "Curbelito Paecito", PhoneNumber = 56784555,
                Address = "Se mudo", 
                DateBecomedMember = new DateTime(2020, 2, 1),
                Tuitor = new Tuitor { Name = "Elena", PhoneNumber = 54637721 }, Founds = 3, 
                ScholarityLevel = Domain.Enums.Education.Primaria },
                   
        };
    }
    
    private static Tuitor[] GetTuitors()
    {
        return new Tuitor[]
        {
            new Tuitor { Name = "Josefa", PhoneNumber = 54674982 }, 
            new Tuitor { Name = "Mari", PhoneNumber = 54637121 },
            new Tuitor{ Name = "Roger", PhoneNumber = 54444444 },
        };
    }
    
    private static Teacher[] GetTeachers()
    {
        return  new Teacher[]
        {
            new Teacher { IDCardNo = "71022200221", Name = "Teresa", LastName = "Graveran",
                PhoneNumber = 59821123, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2008, 9, 5), CourseGroups  = new List<CourseGroup>()}
        };
    }
    
    private static Worker[] GetWorkers()
    {
        return new Worker[]
        {
            new Worker { IDCardNo = "99123100221", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) },
            new Worker { IDCardNo = "99123160221", Name = "Dario", LastName = "Rodriguez Llosa",
                PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                DateBecomedMember = new DateTime(2015, 9, 5) }
        };
    }
    
    #endregion

    #region Records

    private static ExpenseRecord[] GetExpenseRecords()
    {
        return new ExpenseRecord[]{
            new ExpenseRecord { Expense = new Expense { Category = "inmueble", Description = "empty" }, 
                Date = new DateTime(2020), Amount = 1, Value = 200},
        };
    }
    
    private static StudentPaymentRecordForAdditionalService[] GetStudentPaymentRecordForAdditionalServices()
    {
        var worker = new Worker
        {
            IDCardNo = "99197504222", Name = "Luis",
            LastName = "Guerrero", PhoneNumber = 52372293,
            Address = "Espada No.404 e/ San Benito y Esperanza",
            DateBecomedMember = new DateTime(2015, 9, 5)
        };
        var resource = new Resource
        {
            Name = "libro de Ingles basico", Category = "Cuaderno", Price = 1000,
            Providers = new List<Worker>()
        };
        
        return new StudentPaymentRecordForAdditionalService[]
        {
            new StudentPaymentRecordForAdditionalService
            {
                AdditionalService = new AdditionalService
                {
                    Worker = worker,
                    Resource = resource,
                    WorkerPorcentageProfits = 15
                },
                AdditionalServiceResourceId = resource.Id,
                AdditionalServiceWorkerId = worker.Id,
                Student = new Student 
                {
                    IDCardNo = "0998765432158", Name = "Pablo", LastName = "Curbelo Paez", 
                    PhoneNumber = 56784392, Address = "Pocitos No.23 e/ Czda de Vento y ALmendares", 
                    DateBecomedMember = new DateTime(2020, 2, 1), Founds = 3,
                    Tuitor = new Tuitor
                    {
                        Name = "Elena", PhoneNumber = 54637721
                    },  
                    ScholarityLevel = Domain.Enums.Education.Primaria 
                },
                Date = new DateTime(2018,12,02)
            }
        };
    }

    private static StudentPaymentRecordPerCourseGroup[] GetStudentPaymentRecordPerCourseGroups()
    {
        var course = new Course { Name = "Transito 101", Price = 16, Type = "Transito" };

        var courseGroup = new CourseGroup
        {
            Course = course,
            Name = "Aula T2",
            Capacity = 16,
            StartDate = new DateTime(2022, 3, 12),
            EndDate = new DateTime(2022, 5, 12),
            Teacher = new Teacher{ IDCardNo="00523573122", Name = "marcos", LastName = "tirador", PhoneNumber = 76444081,
                Address = "Calle Cotilla", DateBecomedMember = new DateTime(2020, 5, 14), 
                CourseGroups = new List<CourseGroup>() }
        };


        var student = new Student 
        { 
            IDCardNo = "93084574542", Name = "Pablo", LastName = "Curbelo Paez", PhoneNumber = 56784392,
            Address = "Pocitos No.23 e/ Czda de Vento y ALmendares", 
            DateBecomedMember = new DateTime(2020, 2, 1),
            Tuitor = new Tuitor { Name = "Elena", PhoneNumber = 54637721 }, Founds = 3, 
            ScholarityLevel = Domain.Enums.Education.Posgrado 
        };
        return new StudentPaymentRecordPerCourseGroup[]
        {
            new StudentPaymentRecordPerCourseGroup
            {
                CourseGroup = courseGroup, 
                CourseGroupCourseId = course.Id, 
                CourseGroupId = courseGroup.Id, 
                Date = new DateTime(2017,8,12), 
                DatePaid = new DateTime(2017,8, 14),
                StudentId = student.Id, 
                Student = student
            },

            new StudentPaymentRecordPerCourseGroup
            {
                CourseGroup = Aleman,
                CourseGroupCourseId = Aleman.Id,
                CourseGroupId = Aleman.Id,
                Date = new DateTime(2017,8,20),
                DatePaid = new DateTime(2022, 5, 12),
                StudentId = Guillermo.Id,
                Student = Guillermo
            },
             new StudentPaymentRecordPerCourseGroup
            {
                CourseGroup = Aleman,
                CourseGroupCourseId = Aleman.Id,
                CourseGroupId = Aleman.Id,
                Date = new DateTime(2017,8,20),
                DatePaid = new DateTime(2022, 5, 12),
                StudentId = Jorgito.Id,
                Student = Jorgito
            }
        };
    }
    // agregar mas

    private static WorkerPayRecordByPosition[] GetWorkerPayRecordByPositions()
    {        
        var position = new Position { Name = "director", Workers = new List<Worker>() {
            new Worker { IDCardNo = "79082901293", Name = "JUan", LastName = "Baez",
                    PhoneNumber = 56471922, Address = "Espada No.404 e/ San Benito y Esperanza", 
                    DateBecomedMember = new DateTime(2019, 9, 5),
                    Positions = new List<Position>()
                     }, 
        }};
        return new []
        {   
            new WorkerPayRecordByPosition
            {
                Worker = new Worker { IDCardNo = "99124297421", Name = "Alfredo", LastName = "Perez",
                    PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                    DateBecomedMember = new DateTime(2015, 9, 5),
                    Positions = new List<Position>() { position}
                     }, 
                Position = position,
                Date = new DateTime(2017,2,1), Payment = 1500 
            }
        };
    }
    
    private static TeacherPayRecordPerCourse[] GetTeacherPayRecordPerCourses()
    {
        return new []
        {
            new TeacherPayRecordPerCourse
            {
                Course = new Course
                {
                    Name = "Transito 101", Price = 16, Type = "Transito"
                },
                Teacher =new Teacher 
                { 
                    IDCardNo = "95012393872", Name = "Rebeca", LastName = "Portales",
                    PhoneNumber = 59821123, Address = "Espada No.404 e/ San Benito y Esperanza", 
                    DateBecomedMember = new DateTime(2008, 9, 5), 
                    CourseGroups  = new List<CourseGroup>()
                },
                Date = new DateTime(2018,5,23),
                PaidPorcentage =  40
            }
        };
    }
    
    #endregion

    #region Relations

    private static StudentCourseGroupRelation[] GetStudentCourseGroupRelations()
    {
        var courseGroup = new CourseGroup
        {
            Course = new Course { Name = "Transito 101", Price = 16, Type = "Transito" },
            Name = "Aula T3",
            Capacity = 16,
            StartDate = new DateTime(2022, 3, 12),
            EndDate = new DateTime(2022, 5, 12),
            Teacher = new Teacher
            { 
                IDCardNo="00032834123", Name = "marcos", LastName = "tirador", PhoneNumber = 76444081,
                Address = "Calle Cotilla", DateBecomedMember = new DateTime(2020, 5, 14), 
                CourseGroups = new List<CourseGroup>() 
            }
        };
        var student = new Student
        {
            IDCardNo = "08490438573", Name = "Pablo", LastName = "Curbelo Paez", PhoneNumber = 56784392,
            Address = "Pocitos No.23 e/ Czda de Vento y ALmendares",
            DateBecomedMember = new DateTime(2020, 2, 1),
            Tuitor = new Tuitor
            {
                Name = "Elena", PhoneNumber = 54637721
            },
            Founds = 3, ScholarityLevel = Domain.Enums.Education.Posgrado
        };
        return new StudentCourseGroupRelation[]
        {
            new StudentCourseGroupRelation
            {
                CourseGroup = courseGroup, 
                CourseGroupId = courseGroup.Id, 
                CourseGroupCourseId = courseGroup.Course.Id, 
                StartDate = new DateTime(2019,4,12), 
                Student = student,
                StudentId = student.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebralineal,
                CourseGroupCourseId = algebralineal.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebralineal.EndDate,
                StartDate = algebralineal.StartDate,
                Student = sasha,
                StudentId = sasha.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebralineal,
                CourseGroupCourseId = algebralineal.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebralineal.EndDate,
                StartDate = algebralineal.StartDate,
                Student = Carlos,
                StudentId = Carlos.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebralineal,
                CourseGroupCourseId = algebralineal.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebralineal.EndDate,
                StartDate = algebralineal.StartDate,
                Student = Rodrigo,
                StudentId = Rodrigo.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebralineal,
                CourseGroupCourseId = algebralineal.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebralineal.EndDate,
                StartDate = algebralineal.StartDate,
                Student = Hermen,
                StudentId = Hermen.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebra2,
                CourseGroupCourseId = algebra2.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebra2.EndDate,
                StartDate = algebra2.StartDate,
                Student = Hermen,
                StudentId = Hermen.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = algebra2,
                CourseGroupCourseId = algebra2.Id,
                CourseGroupId = algebra.Id,
                EndDate = algebra2.EndDate,
                StartDate = algebra2.StartDate,
                Student = sandra,
                StudentId = sandra.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = historiaDelArte,
                CourseGroupCourseId = historiaDelArte.Id,
                CourseGroupId = algebra.Id,
                EndDate = historiaDelArte.EndDate,
                StartDate = historiaDelArte.StartDate,
                Student = Carlos,
                StudentId = Carlos.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = Aleman,
                CourseGroupCourseId = Aleman.Id,
                CourseGroupId = Aleman.Id,
                EndDate = Aleman.EndDate,
                StartDate = Aleman.StartDate,
                Student = Guillermo,
                StudentId = Guillermo.Id
            },
            new StudentCourseGroupRelation
            {
                CourseGroup = Aleman ,
                CourseGroupCourseId = Aleman.Id,
                CourseGroupId = Aleman.Id,
                EndDate = Aleman.EndDate,
                StartDate = Aleman.StartDate,
                Student = Jorgito,
                StudentId = Jorgito.Id
            }
        };
    }
    
    private static TeacherCourseRelation[] GetTeacherCourseRelations()
    {
        var teacher = new Teacher
        {
            IDCardNo = "75934499884", Name = "Teresa", LastName = "Graveran",
            PhoneNumber = 59821123, Address = "Espada No.404 e/ San Benito y Esperanza",
            DateBecomedMember = new DateTime(2008, 9, 5),
            CourseGroups = new List<CourseGroup>()

        };
        var course = new Course { Name = "Mat PI", Price = 1200, Type = "Matematica" };
        return new []
        {
            new TeacherCourseRelation
            {
                Teacher = teacher,
                TeacherId = teacher.Id,
                Course = course,
                CourseId = course.Id,
                CorrespondingPorcentage = 40
            },
            new TeacherCourseRelation{
                Teacher = juan,
                TeacherId = juan.Id,
                Course = algebra,
                CourseId = algebra.Id,
                CorrespondingPorcentage = 50
            },
            new TeacherCourseRelation{
                Teacher = juan,
                TeacherId = juan.Id,
                Course = geometria,
                CourseId = geometria.Id,
                CorrespondingPorcentage = 50
            },
            new TeacherCourseRelation{
                Teacher = carmen,
                TeacherId = carmen.Id,
                Course = historia,
                CourseId = historia.Id,
                CorrespondingPorcentage = 40
            }
        };
    }
    
    private static TeacherCourseGroupRelation[] GetTeacherCourseGroupRelations()
    {
        var courseGroup = new CourseGroup
        {
            Course = new Course { Name = "Transito 101", Price = 1000, Type = "Transito" },
            Name = "Aula T4",
            Capacity = 16,
            StartDate = new DateTime(2022, 3, 12),
            EndDate = new DateTime(2022, 5, 12),
            Teacher = new Teacher
            { 
                IDCardNo="65423476345", Name = "marcos", LastName = "tirador", PhoneNumber = 76444081,
                Address = "Calle Cotilla", DateBecomedMember = new DateTime(2020, 5, 14), 
                CourseGroups = new List<CourseGroup>() 
            }
        };
        var teacher = new Teacher
        {
            IDCardNo = "78493402348", Name = "Teresa", LastName = "Graveran",
            PhoneNumber = 59821123, Address = "Espada No.404 e/ San Benito y Esperanza",
            DateBecomedMember = new DateTime(2008, 9, 5),
            CourseGroups = new List<CourseGroup>()

        };
        return new []
        {
            new TeacherCourseGroupRelation
            {
                CourseGroup = courseGroup,
                CourseGroupId = courseGroup.Id,
                CourseGroupCourseId = courseGroup.Course.Id,
                Teacher = teacher,
                StartDate = new DateTime(2022,3,21)
            },
            new TeacherCourseGroupRelation
            {
                CourseGroup = algebralineal,
                CourseGroupId = algebralineal.Id,
                StartDate = algebralineal.StartDate,
                EndDate = algebralineal.EndDate,
                Teacher = juan,
                // TeacherId = juan.Id,
                CourseGroupCourseId = algebra.Id
            },
            new TeacherCourseGroupRelation
            {
                CourseGroup = algebra2,
                CourseGroupId = algebra2.Id,
                StartDate = algebra2.StartDate,
                EndDate = algebra2.EndDate,
                Teacher = juan,
                // TeacherId = juan.Id,
                CourseGroupCourseId = algebra.Id
            },
            new TeacherCourseGroupRelation
            {
                CourseGroup = historiaDelArte,
                CourseGroupId = historiaDelArte.Id,
                StartDate = historiaDelArte.StartDate,
                EndDate = historiaDelArte.EndDate,
                Teacher = carmen,
                // TeacherId = carmen.Id,
                CourseGroupCourseId = historia.Id
            },
        };
    }

    private static WorkerPositionRelation[] GetWorkerPositionRelations()
    {
        return new WorkerPositionRelation[]
        {
            new WorkerPositionRelation
            {
                Position = new Position { Name = "Secretaria", Workers = new List<Worker>()},
                Worker = new Worker 
                { 
                    IDCardNo = "83403899900", Name = "Martha", LastName = "Garcia",
                    PhoneNumber = 52813412, Address = "Espada No.404 e/ San Benito y Esperanza", 
                    DateBecomedMember = new DateTime(2015, 9, 5) 
                },
                FixedSalary = 2000,
                StartDate =  new DateTime(2015, 9, 5),
            },
            new WorkerPositionRelation{
                Position = director,
                Worker = carmen,
                FixedSalary = 5000,
                StartDate = carmen.DateBecomedMember
            },
            new WorkerPositionRelation{
                Position = asistente,
                Worker = juan,
                FixedSalary = 3000,
                StartDate = juan.DateBecomedMember
            },
             new WorkerPositionRelation{
                Position = secretaria,
                Worker = carmen,
                FixedSalary = 2000,
                StartDate = carmen.DateBecomedMember
            },
        };
    }
    
    #endregion
#endregion
        
}
