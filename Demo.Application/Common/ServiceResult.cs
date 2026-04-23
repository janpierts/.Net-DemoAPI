namespace Demo.Application.Common;

public class ServiceResult<T>
{
    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T Data { get; private set; }
    public List<string> Errors { get; private set; }

    private ServiceResult(bool success, T data, string message)
    {
        Success = success;
        Data = data;
        Message = message;
        Errors = new List<string>();
    }

    public static ServiceResult<T> Ok(T data, string message = "Éxito") 
        => new ServiceResult<T>(true, data, message);

    public static ServiceResult<T> Failure(string message, List<string> errors = null) 
        => new ServiceResult<T>(false, default, message) { Errors = errors ?? new List<string>() };
}