using Dapper;
using PagingWithDapper.Context;
using PagingWithDapper.Interface;
using PagingWithDapper.Model;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PagingWithDapper.Repository
{
    public class EmployeeRepository : IEmployees
    {
        private readonly DbContext _context;

        public EmployeeRepository(DbContext context)
        {
           _context = context;
        }

        public async Task<PaginatedList<Employee>> GetEmployees(int pageIndex, int pageSize)
        {
            var sql = @"SELECT * FROM Employees ORDER BY id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
                        SELECT COUNT(*) FROM Employees;";

            using(var Connection = _context.CreateConnection())
            {



                var multi = await Connection.QueryMultipleAsync(sql, new { Offset = (pageIndex - 1) * pageSize, PageSize = pageSize });
                var employees = await multi.ReadAsync<Employee>();
                var count = await multi.ReadSingleAsync<int>();

                var totalPages = (int)Math.Ceiling(count / (double)pageSize);

                return new PaginatedList<Employee>(employees.ToList(), pageIndex, totalPages);


            }
        }

        public async Task<Employee> AddEmployees(Employee employee)
        {
            var sql = @"INSERT INTO Employees frist_name,last_name,date_of_birth,email,gender,phoneNumber,department ,salary)
                       VALUES (@frist_name,@last_name ,@date_of_birth ,@email,@gender,@phoneNumber,@department ,@salary); 
                        SELECT SCOPE_IDENTITY();";

           using(var Connection = _context.CreateConnection())
            {
                var id = await Connection.ExecuteScalarAsync<int>(sql, employee);
                employee.id = id; // Assuming id is the primary key of the Employee table

                return employee;
            }
        }
    }
}
