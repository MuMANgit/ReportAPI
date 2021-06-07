using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReportAPP.DAL
{
    public class Report
    {
        /// <summary>
        /// Note - Отчет о проделанной работе,
        /// Hours - Кол-во отработанных часов за текущий день,
        /// Date - Дата заполнения отчета,
        /// EmployeeId - Внешний ключ к работнику.
        /// </summary>
        //[Required]
        public int ReportId { get; set; }
        //[Required(ErrorMessage = "Поле должно быть заполнено")]
        //[StringLength(200, MinimumLength = 15, ErrorMessage = "Длина строки должна быть от 15 до 50 символов")]
        public string Note { get; set; }
        //[Required(ErrorMessage = "Поле должно быть заполнено")]
        //[Range(0, 24, ErrorMessage = "Укажите корректное время")]
        public int Hours { get; set; }
        //[Required]
        public DateTime Date { get; set; }
        //[Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
