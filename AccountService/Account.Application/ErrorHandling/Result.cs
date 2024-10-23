namespace Account.Application.ErrorHandling;

public class Result
{
    public bool Success { get; set; }

    public string Message { get; set; }

    public bool Failure => !Success;

    protected Result(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public static Result Fail(string message)
    {
        return new Result(false, message);
    }

    public static Result<T> Fail<T>(string message)
    {
        return new Result<T>(default(T), false, message);
    }

    public static Result Ok()
    {
        return new Result(true, string.Empty);
    }

    public static Result Ok(string message)
    {
        return new Result(true, message);
    }

    public static Result<T> Ok<T>(T value)
    {
        return new Result<T>(value, true, string.Empty);
    }

    public static Result<T> Ok<T>(T value, string message)
    {
        return new Result<T>(value, true, message);
    }

    public static Result Combine(string message, params Result[] results)
    {
        foreach (Result result in results)
        {
            if (result.Failure)
            {
                return result;
            }
        }

        return Ok(message);
    }
}

public class Result<T> : Result
{
    public T Value { get; private set; }

    protected internal Result(T value, bool success, string message)
        : base(success, message)
    {
        Value = value;
    }
}
