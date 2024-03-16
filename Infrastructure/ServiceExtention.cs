using Abtraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceExtention
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IBetOperations, BetOperations>();
            services.AddScoped<IMatchHistoryOperations, MatchHistoryOperations>();
            services.AddScoped<ITransactionOperations, TransactionOperations>();
            services.AddScoped<IUserOperations, UserOperations>();
        }
    }
}
