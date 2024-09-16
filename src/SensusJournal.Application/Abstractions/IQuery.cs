using MediatR;
namespace SensusJournal.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> where TResponse : class
{
}
