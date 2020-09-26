using ApiDemo2.CircuitBreakers;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo2.Configurations
{
    public static class CircuitBreakerServiceExtension
    {
        public static void AddCircuitBreaker(this IServiceCollection services, int maxFailures, TimeSpan durationOfBreak)
        {
            services.AddSingleton<AsyncCircuitBreakerPolicy>((config) =>
            {
                var circuitBreakerPolicy = Policy.Handle<Exception>()
                                                            .CircuitBreakerAsync(exceptionsAllowedBeforeBreaking: maxFailures, durationOfBreak: durationOfBreak,
                                                            (ex, t) =>
                                                            {
                                                                Console.WriteLine("Circuit broken!");
                                                            },
                                                            () =>
                                                            {
                                                                Console.WriteLine("Circuit Reset!");
                                                            });

                return circuitBreakerPolicy;
            });

            services.AddSingleton<ApiDemo1CircuitBreaker>();
        }
    }
}