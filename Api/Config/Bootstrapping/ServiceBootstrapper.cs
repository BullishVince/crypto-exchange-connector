using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Api.Services;
using Api.Adapters;

namespace Api.Config.Bootstrapping {
    public static class ServiceBootstrapper {
        public static IServiceCollection AddServices(this IServiceCollection services, ApplicationSettings settings) {
            services.AddTransient<ICoinbaseAdapter>(s => new CoinbaseAdapter(settings.CoinbaseSettings.ApiKey, settings.CoinbaseSettings.ApiSecret));
            services.AddTransient<IBinanceAdapter>(s => new BinanceAdapter(settings.BinanceSettings.ApiKey, settings.BinanceSettings.ApiSecret));
            
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IDepositService, DepositService>();
            services.AddScoped<IWithdrawalService, WithdrawalService>();
            return services;
        }
    }
}