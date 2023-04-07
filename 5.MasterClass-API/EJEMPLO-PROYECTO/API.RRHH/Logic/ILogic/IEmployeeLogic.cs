using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IEmployeeLogic
    {
        int InsertEmployee(EmployeeItem employeeItem);
        void UpdateEmployee(EmployeeItem employeeItem);
        void DeleteEmployee(int id);
        List<EmployeeItem> GetAllEmployees();
    }
}
