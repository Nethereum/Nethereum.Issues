using Nethereum.Web3;
using System.Numerics;

namespace Net.Issues.Console.RetrievingAFailedTransaction
{
    public class RetrievingAFailedTransactionSample
    {
        public const string Mainnet = "https://mainnet.infura.io/v3/7238211010344719ad14a89db874158c";

        public async System.Threading.Tasks.Task RunAsync()
        {

            var web3 = new Web3(Mainnet);
            var tx = await web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync("0x6c04b2878bc2579f75e94fd85537348dca2570027d8ed586b97e5a9446fd67a7");
            var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(tx.TransactionHash);

            //check for errors - if none - then it succeeded
            var failed = receipt.HasErrors() ?? false;

            //OR - if running a relatively recent node with default config you can check the status
            // it should be one for success
            // some old nodes or misconfigured nodes may return a null status
            var isFailed = receipt.Status != BigInteger.One;
        }
    }
}
