using EMS.Core.Extensions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EMS.Domains.EntityFramework.Application.Pipelines;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators.Select(x => x.Validate(context))
                                  .SelectMany(x => x.Errors)
                                  .Where(x => x != null)
                                  .ToList();

        if (failures.Any())
        {
            throw new AppException(1000, failures.FirstOrDefault().ErrorMessage, JsonSerializer.Serialize(request));
            //throw new AppException(String.Join("\n" , failures.Select(s => s.ErrorMessage)));
            //throw new ValidationException(failures);
        }

        return next();
    }
}