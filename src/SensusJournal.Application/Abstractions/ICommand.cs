using MediatR;

namespace SensusJournal.Application.Abstractions;

public interface ICommand<TResponse> 
    : IRequest<Result<TResponse>> where TResponse : class
{
}

public interface ICommand : IRequest<Result>
{
}
