/*
 * @CreateTime: Dec 4, 2018 10:08 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 10:15 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Shared.Infrastructure {
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest> {
        private readonly ILogger<TRequest> _logger;

        public RequestLogger (ILogger<TRequest> logger) {
            _logger = logger;
        }
        public Task Process (TRequest request, CancellationToken cancellationToken) {
            var name = typeof (TRequest).Name;

            // TODO: Add User Details
    
            _logger.LogInformation ("Bionic MRP Request: {Name} {@Request}", name, request);

            return Task.CompletedTask;
        }
    }
}