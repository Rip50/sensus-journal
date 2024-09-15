using MediatR;

namespace SensusJournal.Application.Abstractions;

/// <summary>
/// Handler for commands without response
/// </summary>
/// <typeparam name="TCommand"></typeparam>
public interface ICommandHandler<in TCommand> 
    : IRequestHandler<TCommand, Result> 
    where TCommand : ICommand
{
}

/// <summary>
/// Handler for commands with response
/// </summary>
/// <typeparam name="TCommand"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface ICommandHandler<in TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>> 
    where TCommand : ICommand<TResponse>
    where TResponse : class
{
}