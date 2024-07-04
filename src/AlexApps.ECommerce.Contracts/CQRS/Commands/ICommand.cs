using FluentResults;
using MediatR;

namespace AlexApps.ECommerce.Contracts.CQRS.Commands;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}