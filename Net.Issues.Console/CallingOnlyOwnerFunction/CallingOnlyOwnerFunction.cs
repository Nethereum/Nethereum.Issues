using Net.Contracts.CallingOnlyOwnerFunction.ContractDefinition;
using Nethereum.JsonRpc.Client;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using System.Threading.Tasks;

namespace Net.Issues.Console.CallingOnlyOwnerFunction
{
/*
pragma solidity ^0.5.8;

contract Asset {

    event assetCreationAttempt(address indexed sender);
    event assetCreated(address indexed sender, uint indexed id, string indexed name, string price);

    address public owner;

    constructor() public {
        owner = msg.sender;
    }

    function createAsset(uint id,string memory name,string memory price) public returns(bool success) {
        emit assetCreationAttempt(msg.sender);
        require (msg.sender==owner, "sender is not the owner");
        emit assetCreated(msg.sender, id, name, price);
        return true;
    }
}
*/

    public class CallingOnlyOwnerFunctionSample
    {
        public async Task RunAsync()
        {
            const string OwnerPrivateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";

            var ownerAccount = new Account(OwnerPrivateKey);
            var nonOwnerAccount = new ManagedAccount("0x13f022d72158410433cbd66f5dd8bf6d2d129924", "password");

            var web3ForOwner = new Web3(ownerAccount);

            var createAttempEvent = web3ForOwner.Eth.GetEvent<AssetCreationAttemptEventDTO>();
            var createdEvent = web3ForOwner.Eth.GetEvent<AssetCreatedEventDTO>();

            // these filters are supported by Geth - but not by Infura (use web3.Eth.Filters.GetLogs instead)
            // set them up before creating transactions
            var createAttemptFilter = await createAttempEvent.CreateFilterAsync();
            var createdFilter = await createdEvent.CreateFilterAsync();

            System.Console.WriteLine($"Deploying contract.  From Address: {ownerAccount.Address}");
            var deploymentHandler = web3ForOwner.Eth.GetContractDeploymentHandler<AssetDeployment>();
            var deploymentReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(new AssetDeployment
            {
                FromAddress = ownerAccount.Address
            });
            System.Console.WriteLine($"Contract deployed.  Address: {deploymentReceipt.ContractAddress}");

            System.Console.WriteLine("========================================");

            System.Console.WriteLine("Querying owner address");
            var ownerHandler = web3ForOwner.Eth.GetContractQueryHandler<OwnerFunction>();
            var ownerAddress = await ownerHandler.QueryAsync<string>(deploymentReceipt.ContractAddress);
            System.Console.WriteLine($"Owner: {ownerAddress}");

            System.Console.WriteLine("========================================");

            System.Console.WriteLine("Executing createAsset transaction with owner account");
            var createAssetHandler = web3ForOwner.Eth.GetContractTransactionHandler<CreateAssetFunction>();
            var createAssetReceipt = await createAssetHandler.SendRequestAndWaitForReceiptAsync(
                deploymentReceipt.ContractAddress, new CreateAssetFunction
            {
                //FromAddress will default to the account address,
                Id = 1,
                Name = "One",
                Price = "1 Pound"
            });
            System.Console.WriteLine($"Create Asset Result: Status: {createAssetReceipt.Status.Value}, Hash: {createAssetReceipt.TransactionHash}");

            System.Console.WriteLine("========================================");

            System.Console.WriteLine("Demonstrating a failure caused by calling an 'only owner' function by a non-owner");

            System.Console.WriteLine("1 - specifying NON-OWNER account in FromAddress");
            try
            {
                var createAssetFromWrongAccountReceipt = await createAssetHandler.SendRequestAndWaitForReceiptAsync(
                    deploymentReceipt.ContractAddress, new CreateAssetFunction
                    {
                        FromAddress = nonOwnerAccount.Address,
                        Id = 2,
                        Name = "Two",
                        Price = "2 Pounds"
                    });
            }
            catch(RpcResponseException rpcEx)
            {
                System.Console.WriteLine("Create Asset Transaction failed (as expected)");
                System.Console.WriteLine($"Create Asset Error Message: {rpcEx.Message}");
            }

            //re initialise the function handler from the non owner account
            var web3ForNonOwner = new Web3(nonOwnerAccount);
            createAssetHandler = web3ForNonOwner.Eth.GetContractTransactionHandler<CreateAssetFunction>();

            System.Console.WriteLine("2 - specifying a NON-OWNER account on web3");
            try
            {
                var createAssetFromWrongAccountReceipt = await createAssetHandler.SendRequestAndWaitForReceiptAsync(
                    deploymentReceipt.ContractAddress, new CreateAssetFunction
                    {
                        // FromAddress will be defaulted to the account on web3
                        Id = 2,
                        Name = "Two",
                        Price = "2 Pounds"
                    });
            }
            catch (RpcResponseException rpcEx)
            {
                System.Console.WriteLine("Create Asset Transaction failed (as expected)");
                System.Console.WriteLine($"Create Asset Error Message: {rpcEx.Message}");
            }

            System.Console.WriteLine("========================================");
            System.Console.WriteLine("Retrieving events");

            var createAttemptEvents = await createAttempEvent.GetFilterChanges(createAttemptFilter);
            var createdEvents = await createdEvent.GetFilterChanges(createdFilter);

            // you will only get events for transactions that succeeded
            foreach (var createAttemptEvent in createAttemptEvents)
            {
                System.Console.WriteLine($"Create Attempt: From: {createAttemptEvent.Event.Sender}");
            }

            foreach (var e in createdEvents)
            {
                System.Console.WriteLine($"Creation Attempt: From: {e.Event.Sender}, Id: {e.Event.Id}, Name: {e.Event.Name}, Price: {e.Event.Price}");
            }

            System.Console.WriteLine("Finished");
            System.Console.ReadLine();


        }
    
    }
}
