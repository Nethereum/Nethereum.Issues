using System;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using System.Collections.Generic;

namespace SolidityCallAnotherContract.Contracts.Test.DTOs
{
    [FunctionOutput]
    public class CallManyOtherContractsOutputDTO
    {
        [Parameter("bytes[10]", "result", 1)]
        public List<byte[]> Result {get; set;}
    }
}
