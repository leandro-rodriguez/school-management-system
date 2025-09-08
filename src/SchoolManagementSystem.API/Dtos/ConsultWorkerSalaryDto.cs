
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.API.Dtos;

public class InfoByPositionDto
{
    public string PositionId { get; set; }
    public string Position { get; set; }
    public int FixSalaryPosition{get; set;}
}

public class InfoByCourseGroupDto
{
    public string CourseGroupId { get; set; }
    public string CourseGroupName { get; set; }

    public double CourseGroupIncome { get; set; }
    public double CourseGroupWorkerPayment { get; set; }
    
}
public class InfoByCourseDto
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
    public List<InfoByCourseGroupDto> InfoByCourseGroup{get; set;}

}
public class InfoByDateDto
{
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
        ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }

    [DataType(DataType.Currency)]
    public int TotalFixSalary { get{
        int sum = 0;
        foreach(var position in InfoByPosition)
            sum += position.FixSalaryPosition;
        return sum;
    } set{} }

    [DataType(DataType.Currency)]
    public double TotalCoursesPorcentualPayment { get{
        double sum = 0;
        foreach(var course in InfoByCourse)
            sum += course.CourseTotal;
        return sum;
    } set{} }

    [DataType(DataType.Currency)]
    public double Total { get
        {
            return TotalFixSalary + TotalCoursesPorcentualPayment;
        } 
        set{}
    }

    public List<InfoByCourseDto> InfoByCourse{get; set;}
    public List<InfoByPositionDto> InfoByPosition{get; set;}

    // public int TotalAdditionalServicesPorcentualPayment { get; set; }
    // public int Bonification {get; set;}
    // public int Penalization {get; set;}
}

public class ConsultWorkerSalaryGetSingleDto : IDto
{
    public string Id { get; set; }

    public string WorkerName { get; set; }
    
    public List<InfoByDateDto> InfoByDate{get; set;}
}