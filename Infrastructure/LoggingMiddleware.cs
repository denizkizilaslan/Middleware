using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Infrastructure
{
    public class LoggingMiddleware
    {
        private RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)                          
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
                string logMessage = $"{context.Request?.Method} {context.Request?.Path.Value} {context.Response?.StatusCode} {Environment.NewLine}";
                Console.WriteLine(logMessage);
            }
        }
    }
}
