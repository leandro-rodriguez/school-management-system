using SchoolManagementSystem.Application.BusinessLogic.Services_Implementations;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.API.Controllers;

namespace SchoolManagementSystem.API;

class DebtorNotificationService
{
    private readonly ILogger<DebtorNotificationService> _logger;
    private readonly IDoStudentPaymentService _servicePayment;

    public DebtorNotificationService(ILogger<DebtorNotificationService> logger, IDoStudentPaymentService servicePayment)
    {
        _servicePayment = servicePayment;
        _logger = logger;
    }

    public async Task CalculateDebtors()
    {
        int count = 0;
        // List<DebtorDto> debtors = new List<DebtorDto>();
        foreach (Student student in _servicePayment.GetStudentRepo().Query())
        {
            if(DebtorsController.GroupCurseNoPaid(_servicePayment,student.Id).Where(s => DateTime.Now.Date > s.DatePaid.Date).Count() > 0)
                count +=1;
            // foreach(var payment in DebtorsController.GroupCurseNoPaid(_servicePayment,student.Id))
            // {
                // debtors.Add(new DebtorDto
                // {
                //     GroupId = payment.GroupId,
                //     GroupName = payment.GroupName,
                //     IDCardNo = student.IDCardNo,
                //     StudentId = student.Id,
                //     StudentName = student.Name,
                //     StudentLastName = student.LastName,
                //     Debt = payment.CoursePrice,
                //     Dealy = (DateTime.Now.Date - payment.DatePaid).Days
                // });
            // }
        }
        // return Ok(debtors);  

        await Task.Delay(100);
        _logger.LogInformation($"Number of debtors {count}.");

        DebtorsStaticClass.DebtorsAmount = count;
        
    }
}
