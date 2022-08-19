using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Result;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            
            var result = new StandardResult<object>{};
            result.AddError(Code.GenericError,"Erro interno no servidor.");
            var response = JsonConvert.SerializeObject(result.GetResult(), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(response);
        }
    }
}