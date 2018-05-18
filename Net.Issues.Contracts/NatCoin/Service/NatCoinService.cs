using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Net.Contracts.NatCoin.CQS;
using Nethereum.Contracts.CQS;
using Nethereum.RPC.Eth.DTOs;

namespace Net.Contracts.NatCoin.Service
{

    public class NatCoinService
    {
    
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, NatCoinDeployment natCoinDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<NatCoinDeployment>().SendRequestAndWaitForReceiptAsync(natCoinDeployment, cancellationTokenSource);
        }
        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, NatCoinDeployment natCoinDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<NatCoinDeployment>().SendRequestAsync(natCoinDeployment);
        }
        public static async Task<NatCoinService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, NatCoinDeployment natCoinDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, natCoinDeployment, cancellationTokenSource);
            return new NatCoinService(web3, receipt.ContractAddress);
        }
    
        protected Nethereum.Web3.Web3 Web3{ get; }
        
        protected ContractHandler ContractHandler { get; }
        
        public NatCoinService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }
    
        public Task<BigInteger> GetUserBalanceQueryAsync(GetUserBalanceFunction getUserBalanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetUserBalanceFunction, BigInteger>(getUserBalanceFunction, blockParameter);
        }
        public Task<string> CreateUserNatCoinsRequestAsync(CreateUserNatCoinsFunction createUserNatCoinsFunction)
        {
             return ContractHandler.SendRequestAsync(createUserNatCoinsFunction);
        }
        public Task<TransactionReceipt> CreateUserNatCoinsRequestAndWaitForReceiptAsync(CreateUserNatCoinsFunction createUserNatCoinsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createUserNatCoinsFunction, cancellationToken);
        }
    }
}
