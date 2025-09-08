
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Configurations;
using SchoolManagementSystem.Infrastructure.Configurations.Records;
using SchoolManagementSystem.Infrastructure.Configurations.Relations;

namespace SchoolManagementSystem.Infrastructure.Data;

public class SchoolContext : DbContext, IObjectContext
{
    public SchoolContext (DbContextOptions<SchoolContext> options)
        : base(options)
    {
        
    }

    #region Methods and Properties

    IQueryable<TEntity> IObjectContext.Query<TEntity>() => Set<TEntity>();

    void IObjectContext.Add<TEntity>(TEntity entity) => Set<TEntity>().Add(entity);

    void IObjectContext.Update<TEntity>(TEntity entity) => Set<TEntity>().Update(entity);

    void IObjectContext.Remove<TEntity>(TEntity entity) => Set<TEntity>().Remove(entity);

    void IObjectContext.Commit() => SaveChanges();

    Task IObjectContext.CommitAsync() => SaveChangesAsync();

    #endregion


    #region Databases

    // Entities
    public DbSet<AdditionalService> AdditionalServices { get; set; }
    public DbSet<BasicMean> BasicMeans { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseGroup> CourseGroups { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<SchoolMember> SchoolMembers { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Tuitor> Tuitors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Worker> Workers { get; set; }
    
    // Records
    public DbSet<ExpenseRecord> ExpenseRecords { get; set; }
    public DbSet<StudentPaymentRecordForAdditionalService> StudentPaymentRecordForAdditionalServices { get; set; }
    public DbSet<StudentPaymentRecordPerCourseGroup> StudentPaymentRecordPerCourseGroups { get; set; }
    public DbSet<WorkerPayRecordByPosition> WorkerPayRecordByPositions { get; set; }
    public DbSet<TeacherPayRecordPerCourse> TeacherPayRecordPerCourses { get; set; }
    
    // Relations
    public DbSet<StudentCourseGroupRelation> StudentCourseGroupRelations { get; set; }
    public DbSet<TeacherCourseGroupRelation> TeacherCourseGroupRelations { get; set; }
    public DbSet<TeacherCourseRelation> TeacherCourseRelations { get; set; }
    public DbSet<WorkerPositionRelation> WorkerPositionRelations { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Entities
        modelBuilder.ApplyConfiguration(new AdditionalServiceConfiguration());
        modelBuilder.ApplyConfiguration(new BasicMeanConfiguration());
        modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new CourseGroupConfiguration());
        modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
        modelBuilder.ApplyConfiguration(new PositionConfiguration());
        modelBuilder.ApplyConfiguration(new ResourceConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new SchoolMemberConfiguration());
        modelBuilder.ApplyConfiguration(new ShiftConfiguration());
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new TuitorConfiguration());
        modelBuilder.ApplyConfiguration(new WorkerConfiguration());

        // Records
        modelBuilder.ApplyConfiguration(new ExpenseRecordConfiguration());
        modelBuilder.ApplyConfiguration(new StudentPaymentRecordForAdditionalServiceConfiguration());
        modelBuilder.ApplyConfiguration(new StudentPaymentRecordPerCourseGroupConfiguration());
        modelBuilder.ApplyConfiguration(new WorkerPayRecordByPositionConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherPayRecordPerCourseConfiguration());

        // Relations
        modelBuilder.ApplyConfiguration(new StudentCourseGroupRelationConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherCourseGroupRelationConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherCourseRelationConfiguration());
        modelBuilder.ApplyConfiguration(new WorkerPositionRelationConfiguration());
    }
}
