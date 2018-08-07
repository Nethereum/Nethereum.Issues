using System;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
namespace SolidityCallAnotherContract.Contracts.Test.DTOs
{
    [FunctionOutput]
    public class CallAnotherContractOutputDTO:IFunctionOutputDTO
    {
        [Parameter("bytes", "result", 1)]
        public byte[] Result {get; set;}
    }
}
