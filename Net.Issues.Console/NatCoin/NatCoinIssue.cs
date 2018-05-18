using System.Numerics;
using System.Threading.Tasks;
using Net.Contracts.NatCoin.CQS;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace Net.Issues.Console.NatCoin
{
    public class NatCoinIssue
    {
        public static string PrivateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
        public static string Address = "0x12890d2cce102216644c59daE5baed380d84830c";

        public async Task RunAsync()
        {
            var web3 = new Web3(new Account(PrivateKey), "http://localhost:8545");
            var deploymentHandler = web3.Eth.GetContractDeploymentHandler<NatCoinDeployment>();
            var deploymentReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(new NatCoinDeployment() {FromAddress = Address});

            var contracthandler = web3.Eth.GetContractHandler(deploymentReceipt.ContractAddress);
            var createUserNatCoinsMessage = new CreateUserNatCoinsFunction()
            {
                FromAddress = Address,
                Login = "login1",
                Email = "login1@nas.com",
                Id = 1,
                Natcoin = 54
            };

            var receiptSendingId1 = await contracthandler.SendRequestAndWaitForReceiptAsync(createUserNatCoinsMessage);

            var createUserNatCoinsMessage2 = new CreateUserNatCoinsFunction()
            {
                FromAddress = Address,
                Login = "login2",
                Email = "login2@nas.com",
                Id = 2,
                Natcoin = 544
            };

            var receiptSendingId2 = await contracthandler.SendRequestAndWaitForReceiptAsync(createUserNatCoinsMessage2);

            var balance = await contracthandler.QueryAsync<GetUserBalanceFunction, BigInteger>(new GetUserBalanceFunction(){Id = 1});

        }
    }
}
