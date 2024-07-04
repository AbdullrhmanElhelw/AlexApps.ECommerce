using FluentResults;
using MediatR;

namespace AlexApps.ECommerce.Contracts.CQRS.Queries;

public interface IQuery : IRequest<Result>
{
}

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}