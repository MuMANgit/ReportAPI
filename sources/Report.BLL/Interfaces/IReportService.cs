using ReportAPP.BLL.DTO;
using ReportAPP.BLL.tmp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPP.BLL.Interfaces
{
    public interface IReportService
    {
        public QueryResult<ReportDTO> GetReport(int id);
        public QueryResult<List<ReportDTO>> GetReports();
        public Task<QueryResult<ReportDTO>> CreateReportAsync(ReportDTO reportDTO);
        public Task<QueryResult<ReportDTO>> UpdateReportAsync(ReportDTO reportDTO);
        public Task<QueryResult<ReportDTO>> DeleteReportAsync(int id);
        public QueryResult<List<ReportDTO>> GetaMonthlyReportAsync(int employeeId, DateTime beginDate, DateTime endDate);
    }
}
