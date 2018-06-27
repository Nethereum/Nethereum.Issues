using System;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using System.Threading;
using Net.Issues.Contracts.Constructor10.CQS;
using Net.Issues.Contracts.Constructor10.DTOs;
namespace Net.Issues.Contracts.Constructor10.Service
{

    public class Constructor10Service
    {
    
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Web3 web3, Constructor10Deployment constructor10Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<Constructor10Deployment>().SendRequestAndWaitForReceiptAsync(constructor10Deployment, cancellationTokenSource);
        }
        public static Task<string> DeployContractAsync(Web3 web3, Constructor10Deployment constructor10Deployment)
        {
            return web3.Eth.GetContractDeploymentHandler<Constructor10Deployment>().SendRequestAsync(constructor10Deployment);
        }
        public static async Task<Constructor10Service> DeployContractAndGetServiceAsync(Web3 web3, Constructor10Deployment constructor10Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, constructor10Deployment, cancellationTokenSource);
            return new Constructor10Service(web3, receipt.ContractAddress);
        }
    
        protected Web3 Web3{ get; }
        
        protected ContractHandler ContractHandler { get; }
        
        public Constructor10Service(Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }
    
        public Task<BigInteger> FQueryAsync(FFunction fFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FFunction, BigInteger>(fFunction, blockParameter);
        }
    }
}
