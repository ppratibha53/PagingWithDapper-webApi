using Microsoft.AspNetCore.Mvc;
using PagingWithDapper.Interface;
using PagingWithDapper.Model;
using System.Threading.Tasks;

namespace PagingWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployees _employees;

        public EmployeeController(IEmployees employees)
        {
            _employees = employees;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetEmployees(int pageIndex, int pageSize)
        {
            var employee = await _employees.GetEmployees(pageIndex, pageSize);
            return new ApiResponse(true, null, employee);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddEmployee(Employee employee)
        {
            var newEmployee = await _employees.AddEmployees(employee);
            return new ApiResponse(true, null, newEmployee);
        }
    }
}
