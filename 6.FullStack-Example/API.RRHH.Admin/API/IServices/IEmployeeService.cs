using API.Models.Entities;

namespace API.IServices
{
    public interface IEmployeeService
    {
        List<EmployeeItem> GetAllEmployees();
    }
}
