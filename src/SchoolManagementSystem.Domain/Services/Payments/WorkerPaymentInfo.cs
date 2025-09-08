
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Domain;

public class InfoByPosition
{
    public string PositionId { get; set; }
    public string Position { get; set; }
    public int FixSalaryPosition{get; set;}
}

public class InfoByCourseGroup
{
    public string CourseGroupId { get; set; }
    public string CourseGroupName { get; set; }

    public double CourseGroupIncome { get; set; }
    public double CourseGroupWorkerPayment { get; set; }
    
}
public class InfoByCourse
{
    public string CourseId{get;set;}
    public string CourseName {get;set;}

    public int Porcentage { get; set; }
    public double CourseTotal { get{
        double sum = 0;
        foreach(var group in InfoByCourseGroup)
            sum += group.CourseGroupWorkerPayment;
        return sum;
    } set{} }
    public List<InfoByCourseGroup> InfoByCourseGroup{get; set;}

}
public class InfoByDate
{
    public DateTime Date { get; set; }

    public int TotalFixSalary { get{
        int sum = 0;
        foreach(var position in InfoByPosition)
            sum += position.FixSalaryPosition;
        return sum;
    } set{} }

    public double TotalCoursesPorcentualPayment { get{
        double sum = 0;
        foreach(var course in InfoByCourse)
            sum += course.CourseTotal;
        return sum;
    } set{} }

    public double Total { get
        {
            return TotalFixSalary + TotalCoursesPorcentualPayment;
        } 
        set{}
    }
    public List<InfoByCourse> InfoByCourse{get; set;}
    public List<InfoByPosition> InfoByPosition{get; set;}

    // public int TotalAdditionalServicesPorcentualPayment { get; set; }
    // public int Bonification {get; set;}
    // public int Penalization {get; set;}
}

public class WorkerPaymentInfo
{
    public string Id { get; set; }

    public string WorkerName { get; set; }
    
    public List<InfoByDate> InfoByDate{get; set;}
}