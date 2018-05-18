using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Net.Contracts.NatCoin.CQS;
using Net.Contracts.NatCoin.DTOs;
using Nethereum.Contracts.IntegrationTester;
using Xunit;
using Xunit.Abstractions;

namespace Net.Issues.Tests
{
    public class NatcoinTest : NethereumIntegrationTest
    { 
        public NatcoinTest(ITestOutputHelper xunitTestOutputHelper) : base("http://localhost:8545",
            DefaultTestAccountConstants.PrivateKey,
            new NethereumTestDebugLogger(new XunitOutputWriter(xunitTestOutputHelper)))
        {

        }

        [Fact]
        public async Task ShouldGetTheCorrectBalanceAfterSetUserBalance()
        {
            var contractDeploymentDefault = new NatCoinDeployment()
            {
                FromAddress = DefaultTestAccountConstants.Address,
            };

            GivenADeployedContract(contractDeploymentDefault);

            var createUserNatCoinsMessage = new CreateUserNatCoinsFunction()
            {
                FromAddress = DefaultTestAccountConstants.Address,
                Login = "login1",
                Email = "login1@nas.com",
                Id = 1,
                Natcoin = 54
            };

            var createUserNatCoinsMessage2 = new CreateUserNatCoinsFunction()
            {
                FromAddress = DefaultTestAccountConstants.Address,
                Login = "login2",
                Email = "login2@nas.com",
                Id = 2,
                Natcoin = 544
            };
            var receipt1 = GivenATransaction(createUserNatCoinsMessage);
            var receipt2 = GivenATransaction(createUserNatCoinsMessage2);

            WhenQuerying<GetUserBalanceFunction, GetUserBalanceOutputDTO>(new GetUserBalanceFunction() {Id = 1})
                .ThenExpectResult(
                    new GetUserBalanceOutputDTO() {B = 54});

        }

    }
}
