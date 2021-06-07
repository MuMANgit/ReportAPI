using AutoMapper;
using Microsoft.Extensions.Logging;
using ReportAPP.BLL.DTO;
using ReportAPP.BLL.Interfaces;
using ReportAPP.BLL.tmp;
using ReportAPP.DAL;
using ReportAPP.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPP.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeContext db;
        private readonly IMapper mapper;
        private readonly ILogger<EmployeeService> log;
        public EmployeeService(EmployeeContext db, IMapper mapper, ILogger<EmployeeService> log)
        {
            this.db = db;
            this.mapper = mapper;
            this.log = log;
        }

        public QueryResult<List<EmployeeDTO>> GetEmployees()
        {
            QueryResult<List<EmployeeDTO>> result = new QueryResult<List<EmployeeDTO>>();

            try
            {
                result.SuccessResult(mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(db.Employees));
            }
            catch (Exception)
            {
                log.LogError("Text");
                result.ErrorResult("Неизвестная ошибка");
            }

            return result;
        }

        public QueryResult<EmployeeDTO> GetEmployee(int id)
        {
            QueryResult<EmployeeDTO> result = new QueryResult<EmployeeDTO>();

            try
            {
                EmployeeDTO employeeForQuery = mapper.Map<EmployeeDTO>(db.Employees.FirstOrDefault(e => e.EmployeeId == id));

                if (employeeForQuery == null)
                {
                    result.ErrorResult("Пользователь не найден");
                    return result;
                }

                result.SuccessResult(employeeForQuery);
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());

                result.ErrorResult("Неизвестная ошибка");
            }

            return result;
        }

        public async Task<QueryResult<EmployeeDTO>> CreateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            QueryResult<EmployeeDTO> result = new QueryResult<EmployeeDTO>();

            try
            {
                var failVertification = db.Employees.Any(e => e.Email == employeeDTO.Email);

                if (failVertification)
                {
                    result.ErrorResult("Email занят");
                    return result;
                }

                Employee emp = mapper.Map<Employee>(employeeDTO);

                db.Employees.Add(emp);
                await db.SaveChangesAsync();

                EmployeeDTO employeeForQuery = mapper.Map<EmployeeDTO>(emp);

                result.SuccessResult(employeeForQuery);
            }
            catch (Exception)
            {
                log.LogError("Text");
                result.ErrorResult("Неизвестная ошибка");
            }

            return result;
        }

        public async Task<QueryResult<EmployeeDTO>> UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            QueryResult<EmployeeDTO> result = new QueryResult<EmployeeDTO>();

            try
            {

                var notFound = db.Employees.All(e => e.EmployeeId != employeeDTO.EmployeeID);
                if (notFound)
                {
                    result.ErrorResult("Пользователь не найден");
                    return result;
                }

                var failVertification = db.Employees.Any(e => e.Email == employeeDTO.Email && e.EmployeeId != employeeDTO.EmployeeID);
                if (failVertification)
                {
                    result.ErrorResult("Email занят");
                    return result;
                }

                Employee employee = mapper.Map<Employee>(employeeDTO);

                db.Employees.Update(employee);
                await db.SaveChangesAsync();

                EmployeeDTO employeeForQuery = mapper.Map<EmployeeDTO>(employee);

                result.SuccessResult(employeeForQuery);
            }
            catch (Exception)
            {

            }

            return result;
        }

        public async Task<QueryResult<EmployeeDTO>> DeleteEmployeeAsync(int id)
        {
            QueryResult<EmployeeDTO> result = new QueryResult<EmployeeDTO>();

            try
            {
                Employee employee = db.Employees.FirstOrDefault(e => e.EmployeeId == id);

                if (employee == null)
                {
                    result.ErrorResult("Пользователь не найден");
                    return result;
                }

                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                log.LogError("Text");
                result.ErrorResult("Неизвестная ошибка");
            }

            return result;
        }


    }
}
