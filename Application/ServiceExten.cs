using Abtraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceExten
    {
        public static void ConfigureBuisnessServices(this IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IUserMatchHistory, UserMatchHistory>();
            serviceProvider.AddScoped<IMoneyTransaction, MoneyTransaction>();
        }
    }
}
