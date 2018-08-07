using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using System.Threading;
using Net.Issues.Contracts.ArrayUint256Dynamic.CQS;
using Net.Issues.Contracts.ArrayUint256Dynamic.DTOs;
using Nethereum.Contracts.ContractHandlers;

namespace Net.Issues.Contracts.ArrayUint256Dynamic.Service
{

    public class ArrayUint256DynamicService
    {
    
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Web3 web3, ArrayUint256DynamicDeployment arrayUint256DynamicDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ArrayUint256DynamicDeployment>().SendRequestAndWaitForReceiptAsync(arrayUint256DynamicDeployment, cancellationTokenSource);
        }
        public static Task<string> DeployContractAsync(Web3 web3, ArrayUint256DynamicDeployment arrayUint256DynamicDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ArrayUint256DynamicDeployment>().SendRequestAsync(arrayUint256DynamicDeployment);
        }
        public static async Task<ArrayUint256DynamicService> DeployContractAndGetServiceAsync(Web3 web3, ArrayUint256DynamicDeployment arrayUint256DynamicDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, arrayUint256DynamicDeployment, cancellationTokenSource);
            return new ArrayUint256DynamicService(web3, receipt.ContractAddress);
        }
    
        protected Web3 Web3{ get; }
        
        protected ContractHandler ContractHandler { get; }
        
        public ArrayUint256DynamicService(Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }
    
        public Task<List<BigInteger>> GiveMeTheArrayQueryAsync(GiveMeTheArrayFunction giveMeTheArrayFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GiveMeTheArrayFunction, List<BigInteger>>(giveMeTheArrayFunction, blockParameter);
        }
    }
}
