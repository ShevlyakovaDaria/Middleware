using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApplication3
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (string.IsNullOrWhiteSpace(token))
            {
                await context.Response.WriteAsync("This is the main page");
            }
            else
             if (token == "123")
            {
                await context.Response.WriteAsync("You wrote '123'");
            }
            else
            if (token == "456")
            {
                await context.Response.WriteAsync("You wrote '456'");
            }
            else
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
        }

       
    }
        public static class MiddlewareExtensions
        {
            public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<Middleware>();
            }
        }
}
