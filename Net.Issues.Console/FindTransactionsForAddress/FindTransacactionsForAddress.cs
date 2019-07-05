using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Net.Issues.Console.FindTransactionsForAddress
{
    public class FindTransacactionsForAddress
    {
        public async Task RunAsync()
        {
            const string Address = "0x195a07037E97Cd576Ce320bC7fBFBB41D8898b01";
            var web3 = new Web3("https://rinkeby.infura.io/v3/7238211010344719ad14a89db874158c");

            //we're using a known starting block
            var startingBlock = new BigInteger(4668133);

            //get the current block on the chain and use this as the ending block
            var endingBlock = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();

            //initialise the block we'll increment in our loop
            var currentBlockNumber = startingBlock;

            //somewhere to put matching transactions
            List<Transaction> matchingTransactionList = new List<Transaction>();

            while (currentBlockNumber <= endingBlock.Value)
            {
                System.Console.WriteLine($"Requesting transactions for block: {currentBlockNumber}");
                var blockWithTransactions = await web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(currentBlockNumber));

                var matchingTransactions = blockWithTransactions
                    .Transactions
                    .Where(t => t.From.Equals(Address, StringComparison.OrdinalIgnoreCase) || 
                    (t.To != null && t.To.Equals(Address, StringComparison.OrdinalIgnoreCase)));

                Print(matchingTransactions);

                /*
                //if you want receipts - do the following
                foreach(var tx in matchingTransactions)
                {
                    var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(tx.TransactionHash);
                    //if you need to the address of a newly created contract
                    var newlyCreatedContract = receipt.ContractAddress;
                }
                */

                matchingTransactionList.AddRange(matchingTransactions);
                currentBlockNumber = currentBlockNumber + 1;
            }
        }

        private void Print(IEnumerable<Transaction> matchingTransactions)
        {
            if(matchingTransactions.Any())
            { 
                foreach(var tx in matchingTransactions)
                {
                    System.Console.WriteLine($"Block Number: {tx.BlockNumber.Value}, Tx Hash: {tx.TransactionHash}, From: {tx.From}, To: {tx.To}");
                }
            }
            else
            {
                System.Console.WriteLine($"No matching transactions.");
            }
        }
    }
}
