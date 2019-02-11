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
using SolidityTests.Contracts.TokenERC20.ContractDefinition;

namespace SolidityTests.Contracts.TokenERC20
{
    public partial class TokenERC20Service
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, TokenERC20Deployment tokenERC20Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<TokenERC20Deployment>().SendRequestAndWaitForReceiptAsync(tokenERC20Deployment, cancellationTokenSource);
        }
        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, TokenERC20Deployment tokenERC20Deployment)
        {
            return web3.Eth.GetContractDeploymentHandler<TokenERC20Deployment>().SendRequestAsync(tokenERC20Deployment);
        }
        public static async Task<TokenERC20Service> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, TokenERC20Deployment tokenERC20Deployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, tokenERC20Deployment, cancellationTokenSource);
            return new TokenERC20Service(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public TokenERC20Service(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string spender, BigInteger value)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger value)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(decimalsFunction, blockParameter);
        }

        
        public Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(null, blockParameter);
        }

        public Task<string> BurnRequestAsync(BurnFunction burnFunction)
        {
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BurnFunction burnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnRequestAsync(BigInteger value)
        {
            var burnFunction = new BurnFunction();
                burnFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var burnFunction = new BurnFunction();
                burnFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> InitialiseRequestAsync(InitialiseFunction initialiseFunction)
        {
             return ContractHandler.SendRequestAsync(initialiseFunction);
        }

        public Task<TransactionReceipt> InitialiseRequestAndWaitForReceiptAsync(InitialiseFunction initialiseFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initialiseFunction, cancellationToken);
        }

        public Task<string> InitialiseRequestAsync(BigInteger initialSupply, string tokenName, string tokenSymbol, string owneraddress)
        {
            var initialiseFunction = new InitialiseFunction();
                initialiseFunction.InitialSupply = initialSupply;
                initialiseFunction.TokenName = tokenName;
                initialiseFunction.TokenSymbol = tokenSymbol;
                initialiseFunction.Owneraddress = owneraddress;
            
             return ContractHandler.SendRequestAsync(initialiseFunction);
        }

        public Task<TransactionReceipt> InitialiseRequestAndWaitForReceiptAsync(BigInteger initialSupply, string tokenName, string tokenSymbol, string owneraddress, CancellationTokenSource cancellationToken = null)
        {
            var initialiseFunction = new InitialiseFunction();
                initialiseFunction.InitialSupply = initialSupply;
                initialiseFunction.TokenName = tokenName;
                initialiseFunction.TokenSymbol = tokenSymbol;
                initialiseFunction.Owneraddress = owneraddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initialiseFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> BurnFromRequestAsync(BurnFromFunction burnFromFunction)
        {
             return ContractHandler.SendRequestAsync(burnFromFunction);
        }

        public Task<TransactionReceipt> BurnFromRequestAndWaitForReceiptAsync(BurnFromFunction burnFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFromFunction, cancellationToken);
        }

        public Task<string> BurnFromRequestAsync(string from, BigInteger value)
        {
            var burnFromFunction = new BurnFromFunction();
                burnFromFunction.From = from;
                burnFromFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(burnFromFunction);
        }

        public Task<TransactionReceipt> BurnFromRequestAndWaitForReceiptAsync(string from, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var burnFromFunction = new BurnFromFunction();
                burnFromFunction.From = from;
                burnFromFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFromFunction, cancellationToken);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string to, BigInteger value)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string to, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> ApproveAndCallRequestAsync(ApproveAndCallFunction approveAndCallFunction)
        {
             return ContractHandler.SendRequestAsync(approveAndCallFunction);
        }

        public Task<TransactionReceipt> ApproveAndCallRequestAndWaitForReceiptAsync(ApproveAndCallFunction approveAndCallFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveAndCallFunction, cancellationToken);
        }

        public Task<string> ApproveAndCallRequestAsync(string spender, BigInteger value, byte[] extraData)
        {
            var approveAndCallFunction = new ApproveAndCallFunction();
                approveAndCallFunction.Spender = spender;
                approveAndCallFunction.Value = value;
                approveAndCallFunction.ExtraData = extraData;
            
             return ContractHandler.SendRequestAsync(approveAndCallFunction);
        }

        public Task<TransactionReceipt> ApproveAndCallRequestAndWaitForReceiptAsync(string spender, BigInteger value, byte[] extraData, CancellationTokenSource cancellationToken = null)
        {
            var approveAndCallFunction = new ApproveAndCallFunction();
                approveAndCallFunction.Spender = spender;
                approveAndCallFunction.Value = value;
                approveAndCallFunction.ExtraData = extraData;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveAndCallFunction, cancellationToken);
        }

        public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        
        public Task<BigInteger> AllowanceQueryAsync(string returnValue1, string returnValue2, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.ReturnValue1 = returnValue1;
                allowanceFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }
    }
}
