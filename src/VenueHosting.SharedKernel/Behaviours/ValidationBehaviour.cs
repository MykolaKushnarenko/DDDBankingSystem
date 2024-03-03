using ErrorOr;
using FluentValidation;
using MediatR;

namespace VenueHosting.SharedKernel.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehaviour(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            List<Error> errors = validationResult.Errors
                .ConvertAll(x => Error.Validation(x.PropertyName, x.ErrorMessage));
            return (dynamic)errors;
        }

        var result = await next();

        return result;
    }
}