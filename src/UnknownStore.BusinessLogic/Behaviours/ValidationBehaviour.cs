﻿using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using UnknownStore.Common;
using UnknownStore.Common.CQRS;
using UnknownStore.Common.CQRS.Validation;

namespace UnknownStore.BusinessLogic.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : ResponseBase, new() where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ValidationBehaviour<TRequest, TResponse>> _logger;
        private readonly IValidationHandler<TRequest> _validationHandler;

        public ValidationBehaviour(ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public ValidationBehaviour(ILogger<ValidationBehaviour<TRequest, TResponse>> logger,
            IValidationHandler<TRequest> validationHandler)
        {
            _logger = logger;
            _validationHandler = validationHandler;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType();
            if (_validationHandler == null)
            {
                _logger.LogInformation(
                    $"{LoggerMessages.TimeNow}{requestName} does not have a validation handler configured.");
                return await next();
            }

            var result = await _validationHandler.Validate(request, cancellationToken);
            if (!result.IsSuccessful)
            {
                _logger.LogWarning(
                    $"{LoggerMessages.TimeNow}Validation failed for {requestName}. Error: {result.Error}");
                return new TResponse { StatusCode = HttpStatusCode.BadRequest, ErrorMessage = result.Error };
            }

            _logger.LogInformation($"{LoggerMessages.TimeNow}Validation successful for {requestName}.");
            return await next();
        }
    }
}