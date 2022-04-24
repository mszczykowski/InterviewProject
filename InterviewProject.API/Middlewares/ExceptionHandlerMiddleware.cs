using System.Net;
using System.Text.Json;
using InterviewProject.Domain.Exceptions;

namespace InterviewProject.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);

                context.Response.StatusCode = GetStatusCode(exception);

                var result = JsonSerializer.Serialize(new { message = exception.Message });

                await context.Response.WriteAsync(result);
            }
        }

        private int GetStatusCode(Exception exception)
        {
            if (exception is EntityNotFoundException)
            {
                return (int)HttpStatusCode.BadRequest;
            }
            if (exception is PathCannotBeFoundException)
            {
                return (int)HttpStatusCode.NotFound;
            }
            else return (int)HttpStatusCode.InternalServerError;
        }
    }
}
