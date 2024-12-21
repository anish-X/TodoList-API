using Duende.IdentityServer.Events;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TodoList_API.Exceptions;
using TodoList_API.Helpers;

namespace TodoList_API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // get's ready for upcoming middleware pipeline
            }
            catch (UnauthorizedAccessException)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync("Not Authorized!!!");
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync($"{ex.Message}");
            }
            catch (CustomException ex)
            {
                await context.Response.WriteAsJsonAsync($"Error: {ex.Message}");
            }
            catch (RepositoryException ex)
            {
                await context.Response.WriteAsJsonAsync($"Database Error:{ex.Message}");
            }

        }
    }
}
