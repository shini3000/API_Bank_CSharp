using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Application.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var exceptionMapping = new Dictionary<Type, (HttpStatusCode StatusCode, string Title)>
            {
                { typeof(UserInvalidException), (HttpStatusCode.BadRequest, "User Validation Error") },
                { typeof(NotFoundException), (HttpStatusCode.NotFound, "Resource Not Found") },
                { typeof(UnauthorizedAccessException), (HttpStatusCode.Unauthorized, "Unauthorized Access") },
                { typeof(ValidationException), (HttpStatusCode.UnprocessableEntity, "Validation Error") }
            };

            ProblemDetails problemDetails;

            if (exceptionMapping.TryGetValue(ex.GetType(), out var details))
            {
                problemDetails = new ProblemDetails
                {
                    Status = (int)details.StatusCode,
                    Title = details.Title,
                    Detail = ex.Message,
                    Instance = context.Request.Path
                };
            }
            else
            {
                problemDetails = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred. Please try again later.",
                    Instance = context.Request.Path,
                };
            }

            response.StatusCode = problemDetails.Status ?? (int)HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(problemDetails);
            await response.WriteAsync(result);
        }
    }
}
