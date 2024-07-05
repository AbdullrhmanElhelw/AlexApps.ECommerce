using FluentResults;
using FluentValidation;
using MediatR;

namespace AlexApps.ECommerce.Contracts.CQRS.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>
 : IPipelineBehavior<TRequest, TResponse>
 where TRequest : IRequest<TResponse>
 where TResponse : Result
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        Error[] errors = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .Select(error => new Error(error.ErrorMessage))
            .Distinct()
            .ToArray();

        if (errors.Length != 0)
        {
            var errorsAsString = string.Join(", ", errors.Select(e => e.Message));
            return Result.Fail(errorsAsString) as TResponse;
        }

        return await next();
    }
}