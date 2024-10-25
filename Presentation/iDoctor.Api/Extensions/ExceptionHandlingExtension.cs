using Microsoft.AspNetCore.Diagnostics;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace iDoctor.Api.Extensions
{
    public static class ExceptionHandlingExtension
    {
        private static int GetStatusCode(Exception exception) =>
           exception switch
           {
               ArgumentNullException => StatusCodes.Status400BadRequest,
               UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
               KeyNotFoundException => StatusCodes.Status404NotFound,
               FormatException => StatusCodes.Status400BadRequest,
               InvalidOperationException => StatusCodes.Status400BadRequest,
               DbUpdateException => StatusCodes.Status500InternalServerError,
               ValidationException => StatusCodes.Status400BadRequest,
               NotImplementedException => StatusCodes.Status501NotImplemented,
               HttpRequestException => StatusCodes.Status503ServiceUnavailable,
               _ => StatusCodes.Status500InternalServerError
           };
        public static void ConfigureExceptionHandler<T>(this WebApplication application, ILogger<T> logger)
        {
            application.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {                   
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var errorId = Guid.NewGuid().ToString();
                        var exception = contextFeature.Error;

                        logger.LogError($"Error ID: {errorId}, Message: {contextFeature.Error.Message}");

                        var response = new ProblemDetails
                        {
                            Status = context.Response.StatusCode = GetStatusCode(exception),
                            Title = "An error occurred",
                            Detail = exception.Message,
                            Extensions = { ["errorId"] = errorId }
                        };
                  
                        var options = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                            WriteIndented = true
                        };

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
                    }
                });
            });
        }
    }
}
