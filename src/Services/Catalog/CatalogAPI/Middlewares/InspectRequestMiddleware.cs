using System;

namespace CatalogAPI.Middlewares;

public class InspectRequestMiddleware
{
    public RequestDelegate _next;

    public InspectRequestMiddleware(RequestDelegate next)
    {
        _next = next;   
    }

    public async Task InvokeAsync(HttpContext _context)
    {
        await _next(_context);
    }

}
