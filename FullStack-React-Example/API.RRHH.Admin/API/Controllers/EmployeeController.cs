using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Xml.Linq;
using API.IServices;
using API.Models.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost(Name = "GetAllEmployees")]
        public List<EmployeeItem> GetAll()
        {
            return _employeeService.GetAllEmployees();
        }
    }
}
