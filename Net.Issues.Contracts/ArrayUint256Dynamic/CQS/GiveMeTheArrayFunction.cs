using System;
using System.Threading.Tasks;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.Contracts.CQS;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Net.Issues.Contracts.ArrayUint256Dynamic.DTOs;
namespace Net.Issues.Contracts.ArrayUint256Dynamic.CQS
{
    [Function("GiveMeTheArray", "uint256[]")]
    public class GiveMeTheArrayFunction:ContractMessage
    {

    }
}
