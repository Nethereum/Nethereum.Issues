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
using SolidityTests.Contracts.UpgradeabilityProxy.ContractDefinition;

namespace SolidityTests.Contracts.UpgradeabilityProxy
{
    public partial class UpgradeabilityProxyService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, UpgradeabilityProxyDeployment upgradeabilityProxyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<UpgradeabilityProxyDeployment>().SendRequestAndWaitForReceiptAsync(upgradeabilityProxyDeployment, cancellationTokenSource);
        }
        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, UpgradeabilityProxyDeployment upgradeabilityProxyDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<UpgradeabilityProxyDeployment>().SendRequestAsync(upgradeabilityProxyDeployment);
        }
        public static async Task<UpgradeabilityProxyService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, UpgradeabilityProxyDeployment upgradeabilityProxyDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, upgradeabilityProxyDeployment, cancellationTokenSource);
            return new UpgradeabilityProxyService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public UpgradeabilityProxyService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> UpgradeToRequestAsync(UpgradeToFunction upgradeToFunction)
        {
             return ContractHandler.SendRequestAsync(upgradeToFunction);
        }

        public Task<TransactionReceipt> UpgradeToRequestAndWaitForReceiptAsync(UpgradeToFunction upgradeToFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeToFunction, cancellationToken);
        }

        public Task<string> UpgradeToRequestAsync(string newImplementation)
        {
            var upgradeToFunction = new UpgradeToFunction();
                upgradeToFunction.NewImplementation = newImplementation;
            
             return ContractHandler.SendRequestAsync(upgradeToFunction);
        }

        public Task<TransactionReceipt> UpgradeToRequestAndWaitForReceiptAsync(string newImplementation, CancellationTokenSource cancellationToken = null)
        {
            var upgradeToFunction = new UpgradeToFunction();
                upgradeToFunction.NewImplementation = newImplementation;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeToFunction, cancellationToken);
        }

        public Task<string> ImplementationQueryAsync(ImplementationFunction implementationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ImplementationFunction, string>(implementationFunction, blockParameter);
        }

        
        public Task<string> ImplementationQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ImplementationFunction, string>(null, blockParameter);
        }
    }
}
