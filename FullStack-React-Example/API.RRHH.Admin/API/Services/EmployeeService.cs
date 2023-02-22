using API.Data;
using API.IServices;
using API.Models.Entities;

namespace API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ServiceContext _serviceContext;
        public EmployeeService(ServiceContext serviceContext) 
        {
            _serviceContext = serviceContext;
        }
        public List<EmployeeItem> GetAllEmployees()
        {
            return _serviceContext.Set<EmployeeItem>().ToList();
        }
    }
}
