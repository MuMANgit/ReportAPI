using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReportAPP.BLL.DTO
{
    public class ReportDTO
    {
        /// <summary>
        /// ID отчета
        /// </summary>
        public int ReportId { get; set; }
        /// <summary>
        /// Заметка
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(200, MinimumLength = 15, ErrorMessage = "Длина строки должна быть от 15 до 50 символов")]
        public string Note { get; set; }
        /// <summary>
        /// Кол-во отработанных часов
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Range(0, 24, ErrorMessage = "Укажите корректное время")]
        public int Hours { get; set; }
        /// <summary>
        /// Дата заполнения отчета
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
