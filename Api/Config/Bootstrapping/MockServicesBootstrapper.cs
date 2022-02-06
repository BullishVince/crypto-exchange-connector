using Serilog;
using Api.Config.Mocks;

namespace Api.Config.Bootstrapping
{
    public static class MockServicesBootstrapper {
        public static IServiceCollection AddMocks(this IServiceCollection services, ApplicationSettings applicationSettings) {
        if (applicationSettings.UseMocks) {
            Log.Information("Initiating mocked services");

            //Add mocks below
            services.AddSingleton(DepositServiceMock.GetDeposit());
        }
        return services;
        }
    }
}