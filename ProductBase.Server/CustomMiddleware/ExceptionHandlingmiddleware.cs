using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace ProductBase.Server.CustomMiddleware
{
    public class ExceptionHandlingmiddleware
    {
       private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingmiddleware> _logger;
        public ExceptionHandlingmiddleware(RequestDelegate next,ILogger<ExceptionHandlingmiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext); 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType= "application/json";
            var response = context.Response;
            var errorRespons = new ErrorResponse
            { 
                success = false
            };

            switch (exception)
            {
                case ApplicationException ex :
                    if(ex.Message.Contains("Invalid Token"))
                    {
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        errorRespons.message = "Unauthorized access";
                        break;
                    }
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorRespons.message = "Unauthorized access";
                    break;
                case ArgumentException _:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorRespons.message = "Bad request";
                    break;
                    // Add more specific exceptions if needed
            }
            _logger.LogError(exception.Message);
            var result=JsonSerializer.Serialize(errorRespons);
            return context.Response.WriteAsync(result);
        }
    }
}
