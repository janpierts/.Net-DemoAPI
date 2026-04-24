using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Demo.Infrastructure.Middleware;
public class RTimeMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RTimeMiddleware> _logger;

    public RTimeMiddleware(RequestDelegate next, ILogger<RTimeMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        await _next(context);
        stopwatch.Stop();
        var elapsedMs = stopwatch.ElapsedMilliseconds;
        _logger.LogInformation("Request [{Method}] {Path} executed in {ElapsedMilliseconds} ms",
            context.Request.Method, context.Request.Path, elapsedMs);
    }
}