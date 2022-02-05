using Api.Services;
using Bogus;
using FakeItEasy;
using Coinbase.Models;

namespace Api.Config.Mocks {
    public static class DepositServiceMock {
        public static IDepositService GetDeposit() {
            var fakeService = A.Fake<IDepositService>();
            A.CallTo(() => fakeService.GetDeposits(A<string>._))
                .Returns(new []{new Deposit()});
            return fakeService;
        }
    }
}