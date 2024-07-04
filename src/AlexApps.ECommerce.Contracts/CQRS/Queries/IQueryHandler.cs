using FluentResults;
using MediatR;

namespace AlexApps.ECommerce.Contracts.CQRS.Queries;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}