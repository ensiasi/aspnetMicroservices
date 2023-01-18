

using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = Ordering.Application.Exceptions.ValidationException;

namespace Ordering.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResposne> : IPipelineBehavior<TRequest, TResposne> where TRequest : IRequest<TResposne>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResposne> Handle(TRequest request, RequestHandlerDelegate<TResposne> next,
            CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context= new ValidationContext<TRequest>(request);
                var validationResults=await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context,cancellationToken)));
                var failures = validationResults.SelectMany( r => r.Errors).Where(e => e != null).ToList();

                if(failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
