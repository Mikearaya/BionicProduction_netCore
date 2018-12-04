/*
 * @CreateTime: Dec 4, 2018 10:20 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Dec 4, 2018 10:22 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BionicInventory.Application.Shared.Infrastructure {
    public class ReuquestPerformaceLogger<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> {
        private readonly ILogger<TRequest> _logger;
        private readonly Stopwatch _timer;

        public ReuquestPerformaceLogger (ILogger<TRequest> logger) {
            _logger = logger;
            _timer = new Stopwatch ();
        }

        public async Task<TResponse> Handle (TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next) {

            _timer.Start ();

            var response = await next ();

            _timer.Stop ();

            if (_timer.ElapsedMilliseconds > 500) {
                var name = typeof (TRequest).Name;

                // TODO: Add User Details

                Console.WriteLine ($"Bionic MRP Long Running Request: {name} ({_timer.ElapsedMilliseconds} milliseconds) {request}");
                _logger.LogWarning ("Bionic MRP Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}", name, _timer.ElapsedMilliseconds, request);
            }

            return response;
        }
    }
}