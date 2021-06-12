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
    /// Контроллер для действий c Employee
    /// </summary>
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        IEmployeeService employeeService;

        public EmployeeController(IEmployeeService service)
        {
            employeeService = service;
        }
        /// <summary>
        /// Метод для создания Employee
        /// </summary>
        /// <param name="empDTO"></param>
        /// <returns></returns>
        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDTO empDTO)
        {
            if (ModelState.IsValid)
            {
                return Json(await employeeService.CreateEmployeeAsync(empDTO));
            }

            return BadRequest(ModelState);
        }
        /// <summary>
        /// Метод для редактирования Employee
        /// </summary>
        /// <param name="empDTO"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EmployeeDTO empDTO)
        {
            if (ModelState.IsValid)
            {
                return Json(await employeeService.UpdateEmployeeAsync(empDTO));
            }

            return BadRequest(ModelState);
        }
        /// <summary>
        /// Метод для получения всех Employee
        /// </summary>
        /// <returns></returns>
        [Route("All")]
        [HttpGet]
        public IActionResult All()
        {
            return Json(employeeService.GetEmployees());
        }
        /// <summary>
        /// Метод для удаления Employee
        /// </summary>
        /// <param name="id">id удаляемого Employee</param>
        /// <returns></returns>
        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (id != null)
            {
                return Json(await employeeService.DeleteEmployeeAsync((id.Value)));
            }

            return NotFound();
        }
        /// <summary>
        /// Метод для получения Employee
        /// </summary>
        /// <param name="id">id нужного Employee</param>
        /// <returns></returns>
        [Route("Get/{id}")]
        [HttpGet]
        public IActionResult Get([FromRoute] int? id)
        {
            if (id != null)
            {
                return Json(employeeService.GetEmployee(id.Value));
            }

            return NotFound();
        }
    }
}
