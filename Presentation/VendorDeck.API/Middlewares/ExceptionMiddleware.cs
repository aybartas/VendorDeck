using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace VendorDeck.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;
                var response = new ProblemDetails
                {
                    Status = 500,
                    Detail = env.IsDevelopment() ? ex.StackTrace?.ToString() : null,
                    Title = ex.Message,
                };
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);

            }
        }

    }
}
