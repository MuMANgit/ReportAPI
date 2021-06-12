using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReportAPP.BLL.DTO
{
    public class DateDTO
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime BeginDate { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public DateTime EndDate { get; set; }
    }
}
