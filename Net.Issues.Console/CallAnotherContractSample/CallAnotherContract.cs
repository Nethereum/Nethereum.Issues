using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Nethereum.ABI.Decoders;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using SolidityCallAnotherContract.Contracts.Test.CQS;
using SolidityCallAnotherContract.Contracts.TheOther.CQS;

namespace Net.Issues.Console.CallAnotherContractSample
{
    public class CallAnotherContract
    {
        public static string PrivateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
        public static string Address = "0x12890d2cce102216644c59daE5baed380d84830c";

        public async Task RunAsync()
        {
            var web3 = new Web3(new Account(PrivateKey), "http://localhost:8545");
            var deploymentHandler = web3.Eth.GetContractDeploymentHandler<TheOtherDeployment>();
            var deploymentReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync();

            var deploymentCallerHandler = web3.Eth.GetContractDeploymentHandler<TestDeployment>();
            var deploymentReceiptCaller = await deploymentCallerHandler.SendRequestAndWaitForReceiptAsync(); ;
            
           var contracthandler = web3.Eth.GetContractHandler(deploymentReceiptCaller.ContractAddress);

            var callAnotherFunctionMessage = new CallAnotherContractFunction()
            {
                TheOther = deploymentReceipt.ContractAddress
            };
            

            var returnValue = await contracthandler.QueryRawAsync<CallAnotherContractFunction>(callAnotherFunctionMessage);
            var returnStartingAtData = returnValue.Skip(32).ToArray();
            var returnToString = new StringBytes32Decoder().Decode(returnStartingAtData);


            System.Console.WriteLine(returnToString);
        }
    }
}
