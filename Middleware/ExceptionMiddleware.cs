using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using OrdersAPI.Extensions;

namespace OrdersAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
         IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            CustomResponse customResponse = new CustomResponse();
            string genericErrMsg = "We have encountered an issue on server. If continue, please contact administrator";
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                PrepareException(ex, ref context, ref customResponse);
            }
            finally
            {
                if (!string.IsNullOrEmpty(customResponse.ErrorMessage))
                {
                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    var json = JsonSerializer.Serialize(customResponse, options);
                    await context.Response.WriteAsync(json);
                }
            }
        }
        public void PrepareException(Exception ex, ref HttpContext context, ref CustomResponse customResponse)
        {
            customResponse = new CustomResponse
            {
                ErrorMessage = ex.Message,
                IsSuccess = false,
                Result = null,
                StatusCode = HttpStatusCode.InternalServerError,
                ErrorDetails = _env.IsDevelopment() ? ex.StackTrace?.ToString() : null
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            _logger.LogError(ex, ex.StackTrace != null ? ex.StackTrace : ex.Message);
        }
    }
}