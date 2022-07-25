﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.Infrastructure
{
    public class HeaderCheckMiddleware
    {
        private readonly RequestDelegate _next;
        public HeaderCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            var key1 = httpContext.Request.Headers.Keys.Contains("Client-Key");
            var key2 = httpContext.Request.Headers.Keys.Contains("Device-Id");

            if (!key1 || !key2)
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync("Missing requeired keys !");
                return;
            }
            else
            {
            }
            await _next.Invoke(httpContext);
        }
    }
}
