namespace WeatherForecast.Api.Responses;

/// <summary>
/// Represents a standard API response that encapsulates the result data, a success indicator, and an optional message.
/// </summary>
/// <remarks>This class is commonly used to provide a consistent structure for API responses, including both
/// successful and error results. It enables clients to easily interpret the outcome of an API operation and access any
/// returned data or messages.</remarks>
/// <typeparam name="T">The type of the data returned by the API response. Must be a reference type.</typeparam>
public class ApiResponse<T> where T : class
{
    /// <summary>
    /// Initializes a new instance of the ApiResponse class with the specified data, message, and success status.
    /// </summary>
    /// <param name="data">The data to include in the response. This represents the result or payload returned by the API.</param>
    /// <param name="message">The message describing the outcome of the operation. Defaults to a success message if not specified.</param>
    /// <param name="success">A value indicating whether the operation was successful. Defaults to <see langword="true"/>.</param>
    public ApiResponse(T data, string message = "Operação realizada com sucesso.", bool success = true)
    {
        Data = data;
        Message = message;
        Success = success;
    }

    /// <summary>
    /// Gets or sets the data associated with the current instance.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the operation completed successfully.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the message content.
    /// </summary>
    public string Message { get; set; }
}
