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
using PurchaseContracts.Bytes32Array.ContractDefinition;

namespace PurchaseContracts.Bytes32Array
{
    public partial class Bytes32ArrayService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, Bytes32ArrayDeployment bytes32ArrayDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<Bytes32ArrayDeployment>().SendRequestAndWaitForReceiptAsync(bytes32ArrayDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, Bytes32ArrayDeployment bytes32ArrayDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<Bytes32ArrayDeployment>().SendRequestAsync(bytes32ArrayDeployment);
        }

        public static async Task<Bytes32ArrayService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, Bytes32ArrayDeployment bytes32ArrayDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, bytes32ArrayDeployment, cancellationTokenSource);
            return new Bytes32ArrayService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public Bytes32ArrayService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<List<byte[]>> GetStringyQueryAsync(GetStringyFunction getStringyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStringyFunction, List<byte[]>>(getStringyFunction, blockParameter);
        }

        
        public Task<List<byte[]>> GetStringyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStringyFunction, List<byte[]>>(null, blockParameter);
        }
    }
}
