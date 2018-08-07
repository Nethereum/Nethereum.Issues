using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Net.Contracts.NatCoin.DTOs
{
    [FunctionOutput]
    public class GetUserBalanceOutputDTO:IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public BigInteger B {get; set;}
    }
}
