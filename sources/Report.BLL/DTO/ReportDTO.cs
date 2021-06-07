using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReportAPP.BLL.DTO
{
    public class ReportDTO
    {
        public int ReportId { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(200, MinimumLength = 15, ErrorMessage = "Длина строки должна быть от 15 до 50 символов")]
        public string Note { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Range(0, 24, ErrorMessage = "Укажите корректное время")]
        public int Hours { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int EmployeeId { get; set; }
    }
}
