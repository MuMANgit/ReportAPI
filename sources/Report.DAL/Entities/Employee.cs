using System;
using System.Collections.Generic;

namespace ReportAPP.DAL
{
    public class Employee
    {
        /// <summary>
        /// Класс описывающий сотрудника
        /// 
        /// LastName - Фамилия,
        /// FirstName - Имя,
        /// Patronymic - Отчество,
        /// Email - Emai работника.
        /// </summary>

        public int EmployeeId { get; set; }

        //[Required(ErrorMessage = "Поле должно быть заполнено")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        //[Display(Name = "Фамилия")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Поле должно быть заполнено")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        //[Display(Name = "Имя")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Поле должно быть заполнено")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        //[Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        //[Required]
        //[EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        public List<Report> Reports { get; set; }
    }
}
