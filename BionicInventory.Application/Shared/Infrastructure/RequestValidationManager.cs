/*
 * @CreateTime: Dec 4, 2018 10:37 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 10:44 AM
 * @Description: Modify Here, Please 
 */
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Shared.Infrastructure {
    public class RequestValidationManager<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public RequestValidationManager (IEnumerable<IValidator<TRequest>> validators) {

        }

        public Task<TResponse> Handle (TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) {
            var context = new ValidationContext (request);

            var failures = _validators
                .Select (v => v.Validate (context))
                .SelectMany (result => result.Errors)
                .Where (f => f != null)
                .ToList ();

            if (failures.Count != 0) {
                throw new Exceptions.ValidationException (failures);
            }

            return next ();
        }
    }
}