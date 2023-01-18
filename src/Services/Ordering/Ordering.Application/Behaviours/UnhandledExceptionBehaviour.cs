// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Behaviours
{
    internal class UnhandledExceptionBehaviour<TRequest, TResposne> : IPipelineBehavior<TRequest, TResposne> where TRequest : IRequest<TResposne>
    {
        private readonly ILogger<UnhandledExceptionBehaviour<TRequest, TResposne>> _logger;

        public UnhandledExceptionBehaviour(ILogger<UnhandledExceptionBehaviour<TRequest, TResposne>> logger)
        {
            _logger = logger;
        }

        public async Task<TResposne> Handle(TRequest request, RequestHandlerDelegate<TResposne> next,
            CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }catch(Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Application Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}
