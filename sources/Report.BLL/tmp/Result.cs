using System;
using System.Collections.Generic;
using System.Text;

namespace ReportAPP.BLL.tmp
{
    public class QueryResult<T> where T : class
    {
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsSuccess { get; set; } = true;

        public void SuccessResult(T model)
        {
            Result = model;
        }

        public void ErrorResult(string message)
        {
            IsSuccess = false;
            ErrorMessage = message;
        }
    }
}
