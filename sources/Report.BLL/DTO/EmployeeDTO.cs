using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReportAPP.BLL.DTO
{
    /// <summary>
    /// модель описывающая работника
    /// </summary>
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        /// <summary>
        /// Фамилия работника
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        /// <summary>
        /// Имя работника
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество работника
        /// </summary>
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        /// <summary>
        /// Email адрес работника
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
    }
}
