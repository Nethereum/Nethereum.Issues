using System.Threading.Tasks;
using Net.Issues.Contracts.ArrayUint256Dynamic.CQS;
using Nethereum.Geth;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using SolidityTests.Contracts.TokenERC20;
using SolidityTests.Contracts.TokenERC20.ContractDefinition;
using SolidityTests.Contracts.UpgradeabilityProxy;
using SolidityTests.Contracts.UpgradeabilityProxy.ContractDefinition;
using Nethereum.Contracts.Extensions;
using Nethereum.Hex.HexConvertors.Extensions;

namespace Net.Issues.Console.CallAnotherContractSample
{
    public class ProxySample
    {
        public static string PrivateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
        public static string Address = "0x12890d2cce102216644c59daE5baed380d84830c";

        public async Task RunAsync()
        {
            var account = new Account(PrivateKey);
            var web3 = new Web3(account, "http://localhost:8545");

            var tokenDeploymemtReceipt = await TokenERC20Service.DeployContractAndWaitForReceiptAsync(web3, new TokenERC20Deployment()
            {
                InitialSupply = 10000000000,
                Owneraddress = account.Address,
                TokenName = "Test",
                TokenSymbol = "TST"
            });

            var proxyDeploymentReceipt = await UpgradeabilityProxyService.DeployContractAndWaitForReceiptAsync(web3,
                new UpgradeabilityProxyDeployment()
                {
                    Implementation = tokenDeploymemtReceipt.ContractAddress
                });

            var tokenServiceProxy = new TokenERC20Service(web3, proxyDeploymentReceipt.ContractAddress);

            var initReceipt =
                await tokenServiceProxy.InitialiseRequestAndWaitForReceiptAsync(new InitialiseFunction()
                {
                    InitialSupply = 10000000000,
                    Owneraddress = account.Address,
                    TokenName = "This is the biggest token name I can think of, Alfklsfjkslfdjldajflskdafjlsajdflsajdflkasjfdlksjadfljsaflksjadflksajfdlksjadflkjsadflksjafdlksjfjsfljasflkjasdflaskfjasdkflsafjlskdfjlsdkfjldkjsfldkjsflkdjsfaldjsfaldkjsflkjsfdlksfjlkjsfslkdfjaksfljsadkfljkdsfljakdsfjakdsfjdsfljasdflksdajfkljkdfsaflsajdfllskadfjklsajkflksadfjksf",
                    TokenSymbol = "TST"
                });


            //var tokenServiceNormal = new TokenERC20Service(web3, tokenDeploymemtReceipt.ContractAddress);

            var tokenName = await tokenServiceProxy.NameQueryAsync();
            var tokenSymbol = await tokenServiceProxy.SymbolQueryAsync();
            

            var queryHandler =  web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
            var balanceRaw = await queryHandler.QueryRawAsync(proxyDeploymentReceipt.ContractAddress,
                new BalanceOfFunction() {ReturnValue1 = account.Address});

            var balance = await tokenServiceProxy.BalanceOfQueryAsync(account.Address);

            var transferReceipt =
                await tokenServiceProxy.TransferRequestAndWaitForReceiptAsync( new TransferFunction()
                {
                    To= "0x12890d2cce102216644c59daE5baed380d848305",
                    Value = 100
                }
             );

            var log = transferReceipt.DecodeAllEvents<LogAttemptEventDTO>();
            var log2 = transferReceipt.DecodeAllEvents<TransferEventDTO>();

            var balance2 = await tokenServiceProxy.BalanceOfQueryAsync(account.Address);
            

        }
    }
}