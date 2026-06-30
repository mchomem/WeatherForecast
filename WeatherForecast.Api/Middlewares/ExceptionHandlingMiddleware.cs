namespace WeatherForecast.Api.Middlewares;

/// <summary>
/// Middleware responsible for handling exceptions and providing appropriate responses.
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="logger">The logger instance.</param>
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Invokes the middleware to handle exceptions during the request processing.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task that represents the completion of request processing.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro não tratado detectado pelo middleware");
            await HandleExceptionAsync(context, ex);
        }
    }

    /// <summary>
    /// Handles the exception and generates an appropriate response.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="exception">The exception that occurred.</param>
    /// <returns>A task that represents the completion of exception handling.</returns>
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        ApiResponse<string> response;
        int statusCode = 0;

        switch (exception)
        {
            case BusinessException businessException:
                response = new ApiResponse<string>(businessException.Message, "Violação de regra de negócio", false);
                statusCode = (int)HttpStatusCode.BadRequest;
                break;

            case ValidationException validationException:
                var formattedMessage = string.Join(" ", validationException.Errors.Select((e, index) => $"Erro {index + 1}: {e.ErrorMessage}"));

                response = new ApiResponse<string>(formattedMessage, "Erro de validação", false);
                statusCode = (int)HttpStatusCode.BadRequest;
                break;

            default:
                response = new ApiResponse<string>($"Um erro inesperado ocorreu. Detalhes: {exception.Message}", "Internal server error.", false);
                statusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}
