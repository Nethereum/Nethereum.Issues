using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
namespace Net.Issues.Contracts.ArrayUint256Dynamic.DTOs
{
    [FunctionOutput]
    public class GiveMeTheArrayOutputDTO
    {
        [Parameter("uint256[]", "result", 1)]
        public List<BigInteger> Result {get; set;}
    }
}
