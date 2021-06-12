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
    public class ReportService : IReportService
    {
        private readonly EmployeeContext db;
        private readonly IMapper mapper;
        private readonly ILogger<ReportService> log;

        public ReportService(EmployeeContext db, IMapper mapper, ILogger<ReportService> log)
        {
            this.db = db;
            this.mapper = mapper;
            this.log = log;
        }

        public async Task<QueryResult<ReportDTO>> CreateReportAsync(ReportDTO reportDTO) //Обработать исключение FK
        {
            QueryResult<ReportDTO> result = new QueryResult<ReportDTO>();

            try
            {
                var notFound = db.Employees.All(e => e.EmployeeId != reportDTO.EmployeeId);
                if (notFound)
                {
                    result.ErrorResult("Пользователь не найден");

                    return result;
                }

                Report report = mapper.Map<Report>(reportDTO);

                db.Reports.Add(report);
                await db.SaveChangesAsync();

                ReportDTO reportForQuery = mapper.Map<ReportDTO>(report);
                result.SuccessResult(reportForQuery);

                return result;
            }
            catch (Exception)
            {
                ReportDTO reportForEx = reportDTO;

                log.LogError("ошибка", reportForEx);

                result.ErrorResult("Неизвестная ошибка");

                return result;
            }
        }

        public async Task<QueryResult<ReportDTO>> DeleteReportAsync(int id)
        {
            QueryResult<ReportDTO> result = new QueryResult<ReportDTO>();

            try
            {
                Report report = db.Reports.FirstOrDefault(r => r.ReportId == id);

                if (report == null)
                {
                    result.ErrorResult("Отчет не найден");
                    return result;
                }

                db.Reports.Remove(report);
                await db.SaveChangesAsync();

                return result;
            }
            catch (Exception)
            {
                log.LogError("ошибка", id);

                result.ErrorResult("Неизвестная ошибка");

                return result;
            }
        }

        public QueryResult<ReportDTO> GetReport(int id)
        {
            QueryResult<ReportDTO> result = new QueryResult<ReportDTO>();

            try
            {
                ReportDTO reportForQuery = mapper.Map<ReportDTO>(db.Reports.FirstOrDefault(r => r.ReportId == id));

                if (reportForQuery == null)
                {
                    result.ErrorResult("Отчет не найден");
                }

                result.SuccessResult(reportForQuery);

                return result;
            }
            catch (Exception)
            {
                log.LogError("текст", id);
                result.ErrorResult("Неизвестная ошибка");
            }

            return result;
        }

        public QueryResult<List<ReportDTO>> GetReports()
        {
            QueryResult<List<ReportDTO>> result = new QueryResult<List<ReportDTO>>();

            try
            {
                result.SuccessResult(mapper.Map<IEnumerable<Report>, List<ReportDTO>>(db.Reports));
            }
            catch (Exception)
            {
                log.LogError("text");
                result.ErrorResult("Неизвестная ошибка");
            }

            return result;
        }

        public async Task<QueryResult<ReportDTO>> UpdateReportAsync(ReportDTO reportDTO)
        {
            QueryResult<ReportDTO> result = new QueryResult<ReportDTO>();

            try
            {
                var reportNotFound = db.Reports.All(r => r.ReportId != reportDTO.ReportId);
                if (reportNotFound)
                {
                    result.ErrorResult("Отчет не найден");
                    return result;
                }

                Report report = mapper.Map<Report>(reportDTO);

                db.Reports.Update(report);
                await db.SaveChangesAsync();

                ReportDTO reportForQuery = mapper.Map<ReportDTO>(report);

                result.SuccessResult(reportForQuery); return result;
            }
            catch (Exception)
            {

            }

            return result;
        }

        public QueryResult<List<ReportDTO>> GetaMonthlyReportAsync(int employeeId, DateTime beginDate, DateTime endDate)
        {
            QueryResult<List<ReportDTO>> result = new QueryResult<List<ReportDTO>>();

            try
            {
                var notFound = db.Employees.All(e => e.EmployeeId != employeeId);
                if (notFound)
                {
                    result.ErrorResult("Пользователь не найден");
                    return result;
                }

                var reports = db.Reports.Where(e => e.EmployeeId == employeeId && (e.Date >= beginDate && e.Date <= endDate));

                if (reports.Count() == 0)
                {
                    result.ErrorResult("Отчеты не найдены");
                    return result;
                }

                result.SuccessResult(mapper.Map<IEnumerable<Report>, List<ReportDTO>>(reports));
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
