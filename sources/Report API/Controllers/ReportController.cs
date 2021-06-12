using Microsoft.AspNetCore.Mvc;
using ReportAPP.BLL.DTO;
using ReportAPP.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportAPP.Controllers
{
    /// <summary>
    /// Контроллер для действий с отчетами
    /// </summary>
    [Route("Report")]
    public class ReportController : Controller
    {
        IReportService reportService;
        public ReportController(IReportService service)
        {
            reportService = service;
        }
        /// <summary>
        /// Метод для создания отчета
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReportDTO report)
        {
            if (ModelState.IsValid)
            {
                return Json(await reportService.CreateReportAsync(report));
            }

            return BadRequest(ModelState);
        }
        /// <summary>
        /// Метод для редактирования отчета
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ReportDTO report)
        {
            if (ModelState.IsValid)
            {
                return Json(await reportService.UpdateReportAsync(report));
            }

            return BadRequest(ModelState);

        }
        /// <summary>
        /// Метод для удаления отчета
        /// </summary>
        /// <param name="id">id удаляемого отчета</param>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (id != null)
            {
                return Json(await reportService.DeleteReportAsync(id.Value));
            }

            return NotFound();
        }
        /// <summary>
        /// Метод для получения всех отчетов
        /// </summary>
        /// <returns></returns>
        [Route("All")]
        [HttpGet]
        public IActionResult All()
        {
            return Json(reportService.GetReports());
        }
        /// <summary>
        /// Метод для получения отчета
        /// </summary>
        /// <param name="id">id нужного отчета</param>
        /// <returns></returns>
        [Route("Get/{id}")]
        [HttpGet]
        public IActionResult Get([FromRoute] int? id)
        {
            if (id != null)
            {
                return Json(reportService.GetReport(id.Value));
            }

            return NotFound();
        }
        /// <summary>
        /// Метод для получения отчета Employee за определенный отрезок времени
        /// </summary>
        /// <param name="id"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [Route("EmployeeReports/{id}")]
        [HttpGet]
        public IActionResult EmployeeReports([FromRoute] int? id, [FromBody] DateDTO date)
        {
            if (id != null)
            {
                if (ModelState.IsValid)
                {
                    return Json(reportService.GetaMonthlyReportAsync(id.Value, date.BeginDate, date.EndDate));
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }

            return NotFound();
        }

    }
}
