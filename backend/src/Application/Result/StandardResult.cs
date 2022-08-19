using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Result
{
    public class StandardResult<T>
    {
        public Code StatusCode { get; set; }
        public Body<T> Body { get; set; }

        public StandardResult()
        {
            Body = new Body<T>{};
        }
        public void AddError(Code code, string error_message)
        {
            if (this.Body.errors == null)
            {
                this.Body.errors = new List<Error>();
            }
            var error = new Error {
                status = (int)code,
                title = error_message
            };
            this.Body.errors.Add(error);
            this.Body.success = false;
            this.StatusCode = (int)code > (int)Code.Ok ? code : Code.Ok;
        }

        public void AddData(T data)
        {
            this.Body.data = data;
        }

        public StandardResult<T> GetResult()
        {
            if (this.Body.errors == null)
            {
                this.Body.success = true;
                this.StatusCode = Code.Ok;
            }
            return this;
        }

    }
    public class Body<T>
    {
        public bool success { get; set; }
        public List<Error> errors { get; set; }
        public T data { get; set; }
    }

    public class Error
    {
        public int status { get; set; }
        public string title { get; set; }
    }

    public enum Code
    {
        Ok = 200,
        GenericError = 500,
        BusinessError = 422,
        BadRequest = 400,
        NotAuthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        Accepted = 202,
        NoContent = 204,
    }
}
