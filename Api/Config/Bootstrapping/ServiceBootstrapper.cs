using Api.Services;
using Api.Adapters;

namespace Api.Config.Bootstrapping
{
    public static class ServiceBootstrapper {
        public static IServiceCollection AddServices(this IServiceCollection services, ApplicationSettings settings) {
            services.AddTransient<ICoinbaseAdapter>(s => new CoinbaseAdapter(settings.CoinbaseSettings.ApiKey, settings.CoinbaseSettings.ApiSecret));
            services.AddTransient<IBinanceAdapter>(s => new BinanceAdapter(settings.BinanceSettings.ApiKey, settings.BinanceSettings.ApiSecret));
            services.AddScoped<ILocalDataAdapter, LocalDataAdapter>();
            
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IDepositService, DepositService>();
            services.AddScoped<IWithdrawalService, WithdrawalService>();
            services.AddScoped<ITradingService, TradingService>();
            services.AddScoped<IDataService, DataService>();
            return services;
        }
    }
}