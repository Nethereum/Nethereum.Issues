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
using Nethereum.RPC.Eth.DTOs;
using Nethereum.StandardTokenEIP20;
using Nethereum.StandardTokenEIP20.ContractDefinition;
using TransferEventDTO = Nethereum.StandardTokenEIP20.ContractDefinition.TransferEventDTO;
using TransferFunction = Nethereum.StandardTokenEIP20.ContractDefinition.TransferFunction;


namespace Net.Issues.Console.Events
{
    public class EventsSample
    {
        public static string PrivateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
        public static string Address = "0x12890d2cce102216644c59daE5baed380d84830c";

        public async Task RunAsync()
        {
            var account = new Account(PrivateKey);
            var web3 = new Web3(account, "http://localhost:8545");

            var tokenDeploymemtReceipt = await Nethereum.StandardTokenEIP20.StandardTokenService.DeployContractAndWaitForReceiptAsync(web3, new EIP20Deployment()
            {
                InitialAmount = 1000000000000,
                TokenName = "Test",
                TokenSymbol = "TST"
            });

           
            var transferReceipt =
                await new StandardTokenService(web3, tokenDeploymemtReceipt.ContractAddress).TransferRequestAndWaitForReceiptAsync( new TransferFunction()
                {
                    To= "0x12890d2cce102216644c59daE5baed380d848305",
                    Value = 100
                }
             );

            var event1 = web3.Eth.GetEvent<TransferEventDTO>(transferReceipt.ContractAddress);

            var logs = await event1.GetAllChanges(
                event1.CreateFilterInput(new BlockParameter(tokenDeploymemtReceipt.BlockNumber),
                    default(BlockParameter)));
            var abi =
                @"[{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""_from"",""type"":""address""},{""indexed"":true,""name"":""_to"",""type"":""address""},{""indexed"":false,""name"":""_value"",""type"":""uint256""}],""name"":""Transfer"",""type"":""event""}]";
            
            var event2 = web3.Eth.GetContract(abi, transferReceipt.ContractAddress).GetEvent<TransferEventDTO>("Transfer");

            var logs2 = await event2.GetAllChanges(
                event2.CreateFilterInput(new BlockParameter(tokenDeploymemtReceipt.BlockNumber),
                    default(BlockParameter)));


           //mixing definitions, creates the same filter input using the same Abi Event type
            var logs3 = await event2.GetAllChanges(
                event1.CreateFilterInput(new BlockParameter(tokenDeploymemtReceipt.BlockNumber),
                    default(BlockParameter)));

            var logs4 = await event1.GetAllChanges(
                event2.CreateFilterInput(new BlockParameter(tokenDeploymemtReceipt.BlockNumber),
                    default(BlockParameter)));

            //because we are using the event typed we can do something like this, because the definition is extracted from the type, the name as a parameter will be removed later on, as it is not needed.
            var abiEmpty = @"[]";
            var event3 = web3.Eth.GetContract(abiEmpty, transferReceipt.ContractAddress).GetEvent<TransferEventDTO>("Transfer");
            var logs5 = await event3.GetAllChanges(
                event3.CreateFilterInput(new BlockParameter(tokenDeploymemtReceipt.BlockNumber),
                    default(BlockParameter)));

            //if not using a type definition on the first place
            var event4 = web3.Eth.GetContract(abi, transferReceipt.ContractAddress).GetEvent("Transfer");
            var logs6 = await event4.GetAllChanges<TransferEventDTO>(
                event4.CreateFilterInput(new BlockParameter(tokenDeploymemtReceipt.BlockNumber),
                    default(BlockParameter)));

            //mixing different event object types again
            var logs7 = await event4.GetAllChanges<TransferEventDTO>(event1.CreateFilterInput(
                new BlockParameter(tokenDeploymemtReceipt.BlockNumber),
                default(BlockParameter)));

            var logs9 = await event1.GetAllChanges(event4.CreateFilterInput(
                new BlockParameter(tokenDeploymemtReceipt.BlockNumber),
                default(BlockParameter)));


            //using the generated service to create an instance of the Event
            var event5 = new StandardTokenService(web3, tokenDeploymemtReceipt.ContractAddress)
                .GetTransferEvent();

            var logs8 = await event5.GetAllChanges(
                event5.CreateFilterInput(new BlockParameter(tokenDeploymemtReceipt.BlockNumber),
                    default(BlockParameter)));
            
        }
    }
}