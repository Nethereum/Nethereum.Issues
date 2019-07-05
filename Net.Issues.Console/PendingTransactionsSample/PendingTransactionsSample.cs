using System.Threading.Tasks;
using Net.Issues.Contracts.ArrayUint256Dynamic.CQS;
using Nethereum.Geth;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexTypes;
using System.Collections.Generic;
using Nethereum.RPC.Eth.DTOs;

namespace Net.Issues.Console.CallAnotherContractSample
{
    public class PendingTransactionsSample
    {
        public static string PrivateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
        public static string Address = "0x12890d2cce102216644c59daE5baed380d84830c";

        public async Task RunAsync()
        {
            var web3 = new Web3Geth(new Account(PrivateKey), "http://localhost:8545");

            var nonPendingTransactionCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(Address);

            //stop the miner so we can purposefully create pending transactions
            await web3.Miner.Stop.SendRequestAsync();

            //create the filter BEFORE creating new pending transactions
            var pendingFilter = await web3.Eth.Filters.NewPendingTransactionFilter.SendRequestAsync();
            
            //create some transactions (in this case these are contract deployments)
            var deploymentHandler = web3.Eth.GetContractDeploymentHandler<ArrayUint256DynamicDeployment>();
            var txn1 = await deploymentHandler.SendRequestAsync();
            var txn2 = await deploymentHandler.SendRequestAsync();
            var txn3 = await deploymentHandler.SendRequestAsync();

            //get the pending transaction hashes since the filter was created
            var filterChanges = await web3.Eth.Filters.GetFilterChangesForBlockOrTransaction.SendRequestAsync(pendingFilter);

            //OPTIONAL: get the full transaction details for the pending transactions
            List<Transaction> pendingTransactions = new List<Transaction>();
            foreach(var pendingTxHash in filterChanges)
            {
                //as the tx is pending - the block number and transaction index will not be set
                pendingTransactions.Add(await web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(pendingTxHash));
            }

            //start the miner so that it adds the transactions
            await web3.Miner.Start.SendRequestAsync();

            //expect the transaction count to have incremented
            var expectedTransactionCount = nonPendingTransactionCount.Value + filterChanges.Length;
            //wait for miner to complete and ensure the transaction count has incremented
            HexBigInteger newTransactionCount = null;
            do
            {
                newTransactionCount = await web3.Eth.Transactions.GetTransactionCount.SendRequestAsync(Address);
            }
            while(newTransactionCount < expectedTransactionCount);
        }
    }
}