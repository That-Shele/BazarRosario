using BazarLib.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarLib.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void AddBazarApiClient(this IServiceCollection services,
            Action<BazarClientOptions> options)
        {
            services.Configure(options);
            services.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<BazarClientOptions>>().Value;
                return new BazarClientService(options);
            });
        }
    }
}
