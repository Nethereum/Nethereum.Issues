using System;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.Contracts.CQS;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using SolidityCallAnotherContract.Contracts.Test.DTOs;
namespace SolidityCallAnotherContract.Contracts.Test.CQS
{
    [Function("callManyOtherContracts", "bytes[10]")]
    public class CallManyOtherContractsFunction:FunctionMessage
    {
        [Parameter("address", "theOther", 1)]
        public string TheOther {get; set;}
    }
}
