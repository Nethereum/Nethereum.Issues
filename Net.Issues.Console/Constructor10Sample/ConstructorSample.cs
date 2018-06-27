using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Nethereum.ABI.Decoders;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Net.Issues.Contracts.Constructor10.CQS;

namespace Net.Issues.Console.CallAnotherContractSample
{
    public class ConstructorSample
    {
        public static string PrivateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
        public static string Address = "0x12890d2cce102216644c59daE5baed380d84830c";

        public async Task RunAsync()
        {
            var web3 = new Web3(new Account(PrivateKey), "http://localhost:8545");
            var contractDeployment = new Constructor10Deployment()
            {
                F = 10
            };

            var deploymentHandler = web3.Eth.GetContractDeploymentHandler<Constructor10Deployment>();
            var deploymentReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(contractDeployment);

            var contracthandler = web3.Eth.GetContractHandler(deploymentReceipt.ContractAddress);


            var returnValue = await contracthandler.QueryAsync<FFunction, BigInteger>();
            //Assert F == 10
            System.Console.WriteLine(returnValue);
        }
    }
}
