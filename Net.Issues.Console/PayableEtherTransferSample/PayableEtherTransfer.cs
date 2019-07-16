using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Net.Contracts.PayableEtherTransfer;
using Nethereum.Util;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace Net.Issues.Console.PayableEtherTransferSample
{
    public class PayableEtherTransfer
    {
        public async Task RunAsync()
        {
            var keyOfAddressWithSomeEther = "517311d936323b28ca55379280d3b307d354f35ae35b214c6349e9828e809adc";

            // Ethereum network to connect to
            var ethereumNetworkUrl = "https://rinkeby.infura.io/";

            // Sample Purchasing contract deployed on Rinkeby here:
            // https://rinkeby.etherscan.io/address/0x39ff2582beb73781be541cb6dd6ddbade590fc1e#code

            var purchasingContractAddress = "0x39ff2582beb73781be541cb6dd6ddbade590fc1e";

            // Setup web3 and purchasing contract service, to allow us to interact with contract
            var web3 = new Web3(new Account(keyOfAddressWithSomeEther), ethereumNetworkUrl);
            var purchasingService = new PurchasingService(web3, purchasingContractAddress);

            // Show balances before
            var contractBalanceWei = await purchasingService.GetBalanceOfThisQueryAsync();
            var contractBalanceEther = UnitConversion.Convert.FromWei(contractBalanceWei);
            var contractPurchaseCounter = (long)(await purchasingService.PurchaseCounterQueryAsync());
            System.Console.WriteLine($"Before: Contract Eth Balance {contractBalanceEther} Purchase Counter: {contractPurchaseCounter.ToString()}");

            // Buy something from the purchasing contract
            var buySomethingFunctionMessage = new Net.Contracts.PayableEtherTransfer.ContractDefinition.BuySomethingFunction()
            {
                AmountToSend = 100000000000000,
                ProductId = 10,
            };
            var receipt = await purchasingService.BuySomethingRequestAndWaitForReceiptAsync(buySomethingFunctionMessage);
            System.Console.WriteLine($"Status {receipt.Status.Value}");

            // Show balances after
            contractBalanceWei = await purchasingService.GetBalanceOfThisQueryAsync();
            contractBalanceEther = UnitConversion.Convert.FromWei(contractBalanceWei);
            contractPurchaseCounter = (long)(await purchasingService.PurchaseCounterQueryAsync());
            System.Console.WriteLine($"After: Contract Eth Balance {contractBalanceEther} Purchase Counter: {contractPurchaseCounter.ToString()}");

            System.Console.ReadLine();
        }
    }
}
