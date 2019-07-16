using Net.Contracts.CallingOnlyOwnerFunction.ContractDefinition;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Net.Contracts.CallingOnlyOwnerFunction
{
    public partial class AssetService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AssetDeployment assetDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AssetDeployment>().SendRequestAndWaitForReceiptAsync(assetDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AssetDeployment assetDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AssetDeployment>().SendRequestAsync(assetDeployment);
        }

        public static async Task<AssetService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AssetDeployment assetDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, assetDeployment, cancellationTokenSource);
            return new AssetService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AssetService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CreateAssetRequestAsync(CreateAssetFunction createAssetFunction)
        {
             return ContractHandler.SendRequestAsync(createAssetFunction);
        }

        public Task<TransactionReceipt> CreateAssetRequestAndWaitForReceiptAsync(CreateAssetFunction createAssetFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createAssetFunction, cancellationToken);
        }

        public Task<string> CreateAssetRequestAsync(BigInteger id, string name, string price)
        {
            var createAssetFunction = new CreateAssetFunction();
                createAssetFunction.Id = id;
                createAssetFunction.Name = name;
                createAssetFunction.Price = price;
            
             return ContractHandler.SendRequestAsync(createAssetFunction);
        }

        public Task<TransactionReceipt> CreateAssetRequestAndWaitForReceiptAsync(BigInteger id, string name, string price, CancellationTokenSource cancellationToken = null)
        {
            var createAssetFunction = new CreateAssetFunction();
                createAssetFunction.Id = id;
                createAssetFunction.Name = name;
                createAssetFunction.Price = price;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createAssetFunction, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }
    }
}
