namespace SensusJournal.Application.Abstractions;

public class Result
{
    public bool IsSuccess { get; init; }
    public string? Error { get; private set; }

    protected Result(bool isSuccess, string? error = default) 
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success()
    {
        return new Result(true);
    }

    public static Result Failure(string? error = null)
    {
        return new Result(false, error);
    }
}

public class Result<TResponse> : Result where TResponse : class
{
    public bool HasResponse => Response != null;
    public TResponse? Response { get; init; }

    private Result(bool isSuccess, TResponse response, string? error = default) 
        : base(isSuccess, error)
    {
        Response = response;
    }

    private Result(bool isSuccess, string? error = default) 
        : base(isSuccess, error) 
    {
    }

    public static Result<TResponse> Success(TResponse response)
    {
        return new Result<TResponse>(true, response);
    }

    public static new Result<TResponse> Failure(string? error = null)
    {
        return new Result<TResponse>(false);
    }

}