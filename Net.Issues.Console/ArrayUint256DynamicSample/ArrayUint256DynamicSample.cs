using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Net.Issues.Contracts.ArrayUint256Dynamic.CQS;
using Net.Issues.Contracts.ArrayUint256Dynamic.DTOs;
using Nethereum.ABI.Decoders;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Net.Issues.Contracts.Constructor10.CQS;

namespace Net.Issues.Console.CallAnotherContractSample
{
    public class ArrayUint256DynamicSample
    {
        public static string PrivateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
        public static string Address = "0x12890d2cce102216644c59daE5baed380d84830c";

        public async Task RunAsync()
        {
            var web3 = new Web3(new Account(PrivateKey), "http://localhost:8545");
          

            var deploymentHandler = web3.Eth.GetContractDeploymentHandler<ArrayUint256DynamicDeployment>();
            var deploymentReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync();

            var contracthandler = web3.Eth.GetContractHandler(deploymentReceipt.ContractAddress);


            var returnValue = await contracthandler.QueryAsync<GiveMeTheArrayFunction, List<BigInteger>>();

            
            System.Console.WriteLine(returnValue.Count);

            var returnValue2 = await contracthandler.QueryDeserializingToObjectAsync<GiveMeTheArrayFunction, GiveMeTheArrayOutputDTO>();

            System.Console.WriteLine(returnValue2.Result.Count);
        }
    }
}
