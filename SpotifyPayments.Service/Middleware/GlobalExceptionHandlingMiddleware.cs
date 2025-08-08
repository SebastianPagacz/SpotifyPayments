using SpotifyPayment.Domain.Exceptions;

namespace SpotifyPayments.Service.Middleware;

public class GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ItemNotFoundException ex)
        {
            logger.LogWarning(ex, ex.Message);
            context.Response.StatusCode = 404;
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
        catch (AmountPaidException ex)
        {
            logger.LogWarning(ex, ex.Message);
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
        catch(ItemAlreadyExistsException ex)
        {
            logger.LogWarning(ex, ex.Message);
            context.Response.StatusCode = 409;
            await context.Response.WriteAsJsonAsync(new {error = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, ex.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
    }
}
