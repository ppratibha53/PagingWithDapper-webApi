using PagingWithDapper.Model;

namespace PagingWithDapper.Interface
{
    public interface IEmployees
    {
        Task<PaginatedList<Employee>> GetEmployees(int pageIndex, int pageSize);
        Task<Employee> AddEmployees(Employee employee);
    }
}
