namespace SensusJournal.Application.Abstractions;

public class Result
{
    public bool IsSuccess { get; init; }
    public string? Error { get; private set; }
    public ErrorType ErrorType {  get; init; }

    protected Result() { }

    protected Result(bool isSuccess, string? error = default, 
                     ErrorType errorType = ErrorType.GenericError) 
    {
        IsSuccess = isSuccess;
        Error = error;
        ErrorType = errorType;
    }

    public static Result Success()
    {
        return new Result(true);
    }

    public static Result Failure(string? error = null, 
                                 ErrorType errorType = ErrorType.GenericError)
    {
        return new Result(false, error);
    }
}

public class Result<TResponse> : Result where TResponse : class
{
    public bool HasResponse => Response != null;
    public TResponse? Response { get; init; }

    protected Result() { }

    private Result(bool isSuccess, TResponse response, string? error = default) 
        : base(isSuccess, error)
    {
        Response = response;
    }

    private Result(bool isSuccess, string? error = default, 
                   ErrorType errorType = ErrorType.GenericError) 
        : base(isSuccess, error, errorType) 
    {
    }

    public static Result<TResponse> Success(TResponse response)
    {
        return new Result<TResponse>(true, response);
    }

    public static new Result<TResponse> Failure(string? error = null,
                                                ErrorType errorType = ErrorType.GenericError)
    {
        return new Result<TResponse>(false, error, errorType);
    }
}