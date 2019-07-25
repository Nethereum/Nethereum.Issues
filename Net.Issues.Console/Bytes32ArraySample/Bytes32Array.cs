using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nethereum.Web3;
using System.Threading.Tasks;
using PurchaseContracts.Bytes32Array;
using Nethereum.ABI.Decoders;

namespace Net.Issues.Console.Bytes32ArraySample
{
    public class Bytes32Array
    {
        public async Task RunAsync()
        {
            var ethereumNetworkUrl = "https://rinkeby.infura.io/";
            var web3 = new Web3(ethereumNetworkUrl);

            // Bytes32Array contract source code see:
            // https://rinkeby.etherscan.io/address/0x55efb02d754132b16e14ae798868e976ad41380c#code
            var bytes32ArrayService = new Bytes32ArrayService(web3, "0x55efb02d754132b16e14ae798868e976ad41380c");
            var result = await bytes32ArrayService.GetStringyQueryAsync();

            var decoder = new StringBytes32Decoder();
            foreach (var item in result)
            {
                System.Console.WriteLine($"{decoder.Decode(item)}");
            }
            System.Console.ReadLine();
        }
    }
}

