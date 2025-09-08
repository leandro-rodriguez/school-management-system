
namespace SchoolManagementSystem.Application.Authenticate.Models;

public class Response<T> 
{
    public T Result { get;set; }
    public string Status { get; set; }
    public string Message { get; set; }
}

public class Response : Response<string> 
{ 
}
