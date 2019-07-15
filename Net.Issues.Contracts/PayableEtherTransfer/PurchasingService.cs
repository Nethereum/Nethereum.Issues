using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Net.Contracts.PayableEtherTransfer.ContractDefinition;

namespace Net.Contracts.PayableEtherTransfer
{
    public partial class PurchasingService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PurchasingDeployment purchasingDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PurchasingDeployment>().SendRequestAndWaitForReceiptAsync(purchasingDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PurchasingDeployment purchasingDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PurchasingDeployment>().SendRequestAsync(purchasingDeployment);
        }

        public static async Task<PurchasingService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PurchasingDeployment purchasingDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, purchasingDeployment, cancellationTokenSource);
            return new PurchasingService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PurchasingService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> PurchaseCounterQueryAsync(PurchaseCounterFunction purchaseCounterFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PurchaseCounterFunction, BigInteger>(purchaseCounterFunction, blockParameter);
        }

        
        public Task<BigInteger> PurchaseCounterQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PurchaseCounterFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> BuySomethingRequestAsync(BuySomethingFunction buySomethingFunction)
        {
             return ContractHandler.SendRequestAsync(buySomethingFunction);
        }

        public Task<TransactionReceipt> BuySomethingRequestAndWaitForReceiptAsync(BuySomethingFunction buySomethingFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buySomethingFunction, cancellationToken);
        }

        public Task<string> BuySomethingRequestAsync(BigInteger productId)
        {
            var buySomethingFunction = new BuySomethingFunction();
                buySomethingFunction.ProductId = productId;
            
             return ContractHandler.SendRequestAsync(buySomethingFunction);
        }

        public Task<TransactionReceipt> BuySomethingRequestAndWaitForReceiptAsync(BigInteger productId, CancellationTokenSource cancellationToken = null)
        {
            var buySomethingFunction = new BuySomethingFunction();
                buySomethingFunction.ProductId = productId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buySomethingFunction, cancellationToken);
        }

        public Task<BigInteger> GetBalanceOfThisQueryAsync(GetBalanceOfThisFunction getBalanceOfThisFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBalanceOfThisFunction, BigInteger>(getBalanceOfThisFunction, blockParameter);
        }

        
        public Task<BigInteger> GetBalanceOfThisQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBalanceOfThisFunction, BigInteger>(null, blockParameter);
        }
    }
}
