using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public class Result<T>
    {
        public enum resultType { ok, NotFound, Badrequest};

        public resultType ResultType { get; set; }

        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }

        public static Result<T> CreateResult(T value)
        {
            if(value != null) return new Result<T> { IsSuccess = true, Value = value, ResultType = resultType.ok };
            return new Result<T> { IsSuccess = false, ResultType = resultType.NotFound};
        }

        public static Result<T> NotFound() => new Result<T> { ResultType = resultType.NotFound };
        public static Result<T> Failure(string error) => new Result<T> { Error = error, ResultType = resultType.Badrequest };
    }
}
