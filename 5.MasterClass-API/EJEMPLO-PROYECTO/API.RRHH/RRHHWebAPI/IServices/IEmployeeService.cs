using Entities.Entities;

namespace RRHHWebAPI.IServices
{
    public interface IEmployeeService
    {
        int InsertEmployee(EmployeeItem employeeItem);
        void UpdateEmployee(EmployeeItem employeeItem);
        void DeleteEmployee(int id);
        List<EmployeeItem> GetAllEmployees();
    }
}
