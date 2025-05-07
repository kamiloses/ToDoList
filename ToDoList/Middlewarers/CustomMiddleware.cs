using System.Diagnostics;

namespace ToDoList.Middlewarers;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        
        
        var stopwatch = Stopwatch.StartNew();
        await _next(httpContext);
        stopwatch.Stop();
        var duration = stopwatch.ElapsedMilliseconds;
        System.Console.WriteLine($"Request took {duration} ms");

    }
}
