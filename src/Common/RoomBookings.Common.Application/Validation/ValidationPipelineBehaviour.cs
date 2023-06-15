using FluentValidation;
using MediatR;
using RoomBookings.Common.Application.Commands;

namespace RoomBookings.Common.Application.Validation;

public sealed class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull, ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null);

        if (validationFailures.Any())
        {
            throw new ValidationException(validationFailures);
        }

        return await next();
    }
}
