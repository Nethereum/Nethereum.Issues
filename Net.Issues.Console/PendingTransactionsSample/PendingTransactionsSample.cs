using System.Threading.Tasks;
using Net.Issues.Contracts.ArrayUint256Dynamic.CQS;
using Nethereum.Geth;
using Nethereum.Web3.Accounts;

namespace Net.Issues.Console.CallAnotherContractSample
{
    public class PendingTransactionsSample
    {
        public static string PrivateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
        public static string Address = "0x12890d2cce102216644c59daE5baed380d84830c";

        public async Task RunAsync()
        {
            var web3 = new Web3Geth(new Account(PrivateKey), "http://localhost:8545");

            await web3.Miner.Stop.SendRequestAsync();

            var pendingFilter = await web3.Eth.Filters.NewPendingTransactionFilter.SendRequestAsync();
            

            var deploymentHandler = web3.Eth.GetContractDeploymentHandler<ArrayUint256DynamicDeployment>();
            var txn1 = await deploymentHandler.SendRequestAsync();
            var txn2 = await deploymentHandler.SendRequestAsync();
            var txn3 = await deploymentHandler.SendRequestAsync();

            var filterChanges = await web3.Eth.Filters.GetFilterChangesForBlockOrTransaction.SendRequestAsync(pendingFilter);
        }
    }
}