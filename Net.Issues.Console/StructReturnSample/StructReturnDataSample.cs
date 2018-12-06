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
using Net.Contracts.TestStructOutput.ContractDefinition;

namespace Net.Issues.Console.StructReturnData
{
    //Solidity

        /*
        pragma solidity ^0.5.0;
        pragma experimental ABIEncoderV2;

        contract TestStructOutput {

        struct File{
            bytes32 fileName;
            string imageHash;
        }

        function getData() public view returns (File memory test) {
            if(msg.sender == 0x12890D2cce102216644c59daE5baed380d84830c){
                return File("myfile", "0x123456");
            }
            return File("anotherFile", "0x1111");
        }

        function getData2() public view returns (bytes32 fileName, string memory imageHash) {

            if(msg.sender == 0x12890D2cce102216644c59daE5baed380d84830c){
                fileName = "myfile";
                imageHash = "0x123456";
            } else {
                fileName = "anotherFile";
                imageHash = "0x1111";
            }
        }
       }
*/



public class StructReturnDataSample
{
    public static string PrivateKey = "0xb5b1870957d373ef0eeffecc6e4812c0fd08f554b37b233526acc331bf1544f7";
    public static string Address = "0x12890d2cce102216644c59daE5baed380d84830c";

    public async Task RunAsync()
    {
        var web3 = new Web3(new Account(PrivateKey), "http://localhost:8545");

        var transactionReceipt = await web3.Eth.GetContractDeploymentHandler<TestStructOutputDeployment>().SendRequestAndWaitForReceiptAsync();
        var contractAddress = transactionReceipt.ContractAddress;

        var contracthandler = web3.Eth.GetContractHandler(contractAddress);

        var returnValue = await contracthandler.QueryDeserializingToObjectAsync<GetDataFunction, GetDataOutputDTO>();

        System.Console.WriteLine(returnValue.Test.FileName);
        System.Console.WriteLine(returnValue.Test.ImageHash);


        var returnValue2 = await contracthandler.QueryDeserializingToObjectAsync<GetData2Function, GetData2OutputDTO>();

        System.Console.WriteLine(returnValue2.FileName);
        System.Console.WriteLine(returnValue2.ImageHash);


    }
}
}
