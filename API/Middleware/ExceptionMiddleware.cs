using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Exceptions;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            try 
            {
                await _next(context);
            }
            catch(UserExistsException)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsync("User already exists");
            }
            catch(InvalidCredentialsException)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Invalid credentials");
            }
        }
    }
}