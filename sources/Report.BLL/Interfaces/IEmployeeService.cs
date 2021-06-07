using ReportAPP.BLL.DTO;
using ReportAPP.BLL.tmp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPP.BLL.Interfaces
{
    public interface IEmployeeService
    {
        public QueryResult<EmployeeDTO> GetEmployee(int id);
        public QueryResult<List<EmployeeDTO>> GetEmployees();
        public Task<QueryResult<EmployeeDTO>> CreateEmployeeAsync(EmployeeDTO employee);
        public Task<QueryResult<EmployeeDTO>> UpdateEmployeeAsync(EmployeeDTO employee);
        public Task<QueryResult<EmployeeDTO>> DeleteEmployeeAsync(int id);
    }
}
